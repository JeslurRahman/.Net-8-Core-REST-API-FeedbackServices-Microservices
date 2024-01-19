using FeedbackService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.Core.Interfaces.Repositories
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<FeedbackDTO>> GetAllAsync();
        Task<FeedbackDTO> GetByIdAsync(int id);
        Task<FeedbackDTO> CreateAsync(FeedbackDTO feedbackDTO);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, FeedbackDTO feedbackDTO);
    }
}
