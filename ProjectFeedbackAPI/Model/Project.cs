using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectFeedbackAPI.Model
{
    [Table("projects")]
    public partial class Project
    {
        [Required]
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Name { get; set; }

        [Required]
        [Column("grade")]
        [Range(0, 5)]
        public int? Grade { get; set; }

        [Required]
        [Column("feedback")]
        [StringLength(200)]
        [Unicode(false)]
        public string? Feedback { get; set; }

    }
}
