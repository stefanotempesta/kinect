using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KinectApi.Models
{
    public class KinectApiContext : DbContext
    {
        public KinectApiContext() : base("name=KinectApiContext")
        {
        }

        public System.Data.Entity.DbSet<KinectApi.Models.Quiz> Quizzes { get; set; }

        public System.Data.Entity.DbSet<KinectApi.Models.Question> Questions { get; set; }

        public System.Data.Entity.DbSet<KinectApi.Models.Answer> Answers { get; set; }
    }
}
