using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuizApp.Models
{
    public class QuizAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public QuizAppContext() : base("name=QuizAppContext")
        {
        }

        public System.Data.Entity.DbSet<KinectApi.Models.Quiz> Quizs { get; set; }

        public System.Data.Entity.DbSet<KinectApi.Models.Question> Questions { get; set; }

        public System.Data.Entity.DbSet<KinectApi.Models.Answer> Answers { get; set; }
    }
}
