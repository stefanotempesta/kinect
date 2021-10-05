using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectApi.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Question")]
        public string Text { get; set; }

        public int Duration { get; set; }

        [DisplayName("Quiz")]
        public int QuizId { get; set; }

        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }

        public virtual IEnumerable<Answer> Answers { get; set; }
    }
}
