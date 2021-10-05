using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectApi.Models
{
    public class Quiz
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Subject")]
        public string Name { get; set; }

        public virtual IEnumerable<Question> Questions { get; set; }
    }
}
