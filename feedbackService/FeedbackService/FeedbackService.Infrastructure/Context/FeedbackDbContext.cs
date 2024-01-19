using FeedbackService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackService.Infrastructure.Context
{
    public class FeedbackDbContext : DbContext
    {
        public FeedbackDbContext(DbContextOptions<FeedbackDbContext> option) : base(option)
        {
            //SeedData();
        }
        public virtual DbSet<Feedback> Feedbacks { get; set; }

        //Sample Data
        //private void SeedData()
        //{
        //    var feedbacks = new List<Feedback>()
        //    {
        //        new Feedback() {Id = 1, Subject = ".Net Core 08 Web API", Message = "xyz 01", Rating = 8, CreatedBy = "Jeslur", CreatedDate= new DateTime()},
        //        new Feedback() {Id = 2, Subject = ".Net Core 07 Web API", Message = "xyz 02", Rating = 8, CreatedBy = "Rifkhan", CreatedDate= new DateTime()},
        //        new Feedback() {Id = 3, Subject = ".Net Core 06 Web API", Message = "xyz 03", Rating = 8, CreatedBy = "Aksham", CreatedDate= new DateTime()},
        //        new Feedback() {Id = 4, Subject = ".Net Core 05 Web API", Message = "xyz 04", Rating = 8, CreatedBy = "Risny", CreatedDate= new DateTime()},
        //        new Feedback() {Id = 5, Subject = ".Net Core 04 Web API", Message = "xyz 05", Rating = 8, CreatedBy = "Rikas", CreatedDate= new DateTime()}
        //    };

        //    Feedbacks.AddRange(feedbacks);
        //    SaveChanges();
        //}
    }
}
