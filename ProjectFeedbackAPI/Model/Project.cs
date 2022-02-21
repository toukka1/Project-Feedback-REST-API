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
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Name { get; set; }
        [Column("grade")]
        public int? Grade { get; set; }
        [Column("feedback")]
        [StringLength(200)]
        [Unicode(false)]
        public string? Feedback { get; set; }
    }
}
