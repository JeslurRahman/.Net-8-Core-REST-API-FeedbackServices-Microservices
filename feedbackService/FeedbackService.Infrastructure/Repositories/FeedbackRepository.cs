using AutoMapper;
using FeedbackService.Core.Interfaces.Repositories;
using FeedbackService.Core.Models;
using FeedbackService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.Infrastructure.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public readonly FeedbackDbContext _feedbackDbContext;
        public readonly IMapper _mapper;
        public FeedbackRepository(FeedbackDbContext feedbackDbContext, IMapper mapper) 
        {
            _feedbackDbContext = feedbackDbContext ?? throw new ArgumentNullException(nameof(feedbackDbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<FeedbackDTO> CreateAsync(FeedbackDTO feedbackDTO)
        {
            var feedback = _mapper.Map<Entities.Feedback>(feedbackDTO);
            await _feedbackDbContext.AddAsync(feedback);
            await _feedbackDbContext.SaveChangesAsync();
            return feedbackDTO;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var feedback = await _feedbackDbContext.Feedbacks.FindAsync(id);
            if(feedback != null)
            {
                _feedbackDbContext.Feedbacks.Remove(feedback);
                await _feedbackDbContext.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<bool> UpdateAsync(int id, FeedbackDTO feedbackDTO)
        {
            var feedback = await _feedbackDbContext.Feedbacks.FindAsync(id);
            if(feedback == null || feedback.Id != id)
            {
                return false;
            }
            //_feedbackDbContext.Entry(feedback).State = EntityState.Modified;
            feedback.Subject = feedbackDTO.Subject;
            feedback.Message = feedbackDTO.Message;
            feedback.Rating = feedbackDTO.Rating;
            feedback.CreatedBy = feedbackDTO.CreatedBy;
            feedback.CreatedDate = DateTime.Now;

            if(feedback != null)
            {
                _feedbackDbContext.Feedbacks.Update(feedback);
                await _feedbackDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<FeedbackDTO>> GetAllAsync()
        {
            var feedback = await _feedbackDbContext.Feedbacks.ToListAsync().ConfigureAwait(false);
            if(feedback != null)
            {
                return _mapper.Map<IEnumerable<FeedbackDTO>>(feedback);
            }
            return null;
            
        }

        public async Task<FeedbackDTO> GetByIdAsync(int id)
        {
            var feedback = await _feedbackDbContext.Feedbacks.FindAsync(id);
            if(feedback != null)
            {
                return _mapper.Map<FeedbackDTO>(feedback);
            }
            return null;
        }
    }
}
