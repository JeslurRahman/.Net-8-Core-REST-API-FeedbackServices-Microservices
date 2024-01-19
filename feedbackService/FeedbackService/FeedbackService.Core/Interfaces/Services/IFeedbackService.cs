using FeedbackService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.Core.Interfaces.Services
{
    public interface IFeedbackService
    {
        Task<IEnumerable<FeedbackDTO>> GetAllFeedbacksAsync();
        Task<FeedbackDTO> GetFeedbackByIdAsync(int id);
        Task<FeedbackDTO> CreateFeedbackAsync(FeedbackDTO feedbackDTO);
        Task<bool> DeleteFeedbackAsync(int id);
        Task<bool> UpdateFeedbackAsync(int id, FeedbackDTO feedback);
    }
}
