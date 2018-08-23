using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AngularWebApplication.Data.Models
{
    public class ApplicationUser
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        public string DisplayName { get; set; }

        public string Notes { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public int Flags { get; set; }

        [Required]
        public DateTime CretedDate { get; set; }

        [Required]
        public DateTime LastModified { get; set; }

        public virtual List<Quiz> Quizzes { get; set; }
    }
}
