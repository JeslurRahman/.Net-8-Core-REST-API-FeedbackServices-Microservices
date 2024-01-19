using FeedbackService.Core.Interfaces.Repositories;
using FeedbackService.Core.Interfaces.Services;
using FeedbackService.Core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.Core.Services
{
    public class FeedbacksService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly ILogger<FeedbacksService> _logger;
        public FeedbacksService(IFeedbackRepository feedbackRepository, ILogger<FeedbacksService> logger)
        {
            _feedbackRepository = feedbackRepository ?? throw new ArgumentNullException(nameof(feedbackRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<FeedbackDTO> CreateFeedbackAsync(FeedbackDTO feedbackDTO)
        {
            try
            {
                if (feedbackDTO == null)
                {
                    throw new ArgumentNullException(nameof(feedbackDTO));
                }
                return await _feedbackRepository.CreateAsync(feedbackDTO);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while trying to call CreateFeedback in service class, Error message{exception}");
                throw;
            }
        }

        public async Task<bool> DeleteFeedbackAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentNullException(nameof(id));
                }
                return await _feedbackRepository.DeleteAsync(id);

            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while trying to call DeleteFeedback in service class, Error message{exception}");
                throw;
            }
        }

        public async Task<bool> UpdateFeedbackAsync(int id, FeedbackDTO feedbackDTO)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentNullException(nameof(id));
                }
                if (feedbackDTO == null)
                {
                    throw new ArgumentNullException(nameof(feedbackDTO));
                }
                return await _feedbackRepository.UpdateAsync(id, feedbackDTO);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while trying to call UpdateFeedback in service class, Error message{exception}");
                throw;
            }
        }

        public async Task<IEnumerable<FeedbackDTO>> GetAllFeedbacksAsync()
        {
            try
            {
                //throw new ArgumentNullException();
                return await _feedbackRepository.GetAllAsync();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while trying to call GetAllFeedbacks in sercvice class, Error Mesage ={exception}");
                throw;
            }
        }

        public async Task<FeedbackDTO> GetFeedbackByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentNullException(nameof(id));
                }
                return await _feedbackRepository.GetByIdAsync(id);
            }
            catch (Exception exception)
            {

                _logger.LogError($"Error while trying to call GetFeedbackByID in service class, Error message{exception}");
                throw;
            }
        }
    }
}
