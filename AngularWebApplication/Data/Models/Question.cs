using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularWebApplication.Data.Models
{
    public class Question : BaseModel
    {
        [Required]
        public int QuizId { get; set; }

        [Required]
        public string Text { get; set; }

        [ForeignKey("QuizId")]
        public virtual Quiz Quiz { get; set; }

        public virtual List<Answer> Answers { get; set; }


    }
}
