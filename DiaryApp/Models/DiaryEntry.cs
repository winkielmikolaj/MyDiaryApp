﻿using System.ComponentModel.DataAnnotations;

namespace DiaryApp.Models
{
    public class DiaryEntry
    {
        [Key] /*entity robi to samodzielnie, ale wsm ja sobi to zostawie*/
        public int Id { get; set; }
        //[Required(ErrorMessage ="Please enter a Title")]
        //[StringLength(100, MinimumLength = 3, ErrorMessage ="Title must be between 3 and 100 characters!")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a description")]
        public string Content { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a Date")]
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
