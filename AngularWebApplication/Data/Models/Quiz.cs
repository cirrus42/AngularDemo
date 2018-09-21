using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularWebApplication.Data.Models
{
    public class Quiz : BaseModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public string Text { get; set; }

        [Required]
        public string UserId { get; set; }

        public int ViewCount { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public virtual List<Question> Questions { get; set; }

        public virtual List<Result> Results { get; set; }

    }
}
