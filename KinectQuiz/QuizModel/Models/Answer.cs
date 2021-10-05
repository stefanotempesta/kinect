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
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Answer")]
        public string Text { get; set; }

        [DisplayName("Correct")]
        public bool IsCorrect { get; set; }

        [DisplayName("Question")]
        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}
