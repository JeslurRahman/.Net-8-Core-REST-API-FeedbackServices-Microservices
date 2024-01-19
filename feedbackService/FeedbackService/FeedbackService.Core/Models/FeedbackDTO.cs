using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FeedbackService.Core.Models
{
    public class FeedbackDTO
    {
        //ignored
        [JsonIgnore]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int Rating { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
