using System;
using System.ComponentModel.DataAnnotations;

namespace CoreLab.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter student's name")]
        [MaxLength(30, ErrorMessage = "Name cannot be larger than 30 symbols")]
        [MinLength(2, ErrorMessage = "Name cannot be less than 2 symbols")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please enter student's surname")]
        [MaxLength(30, ErrorMessage = "Surname cannot be larger than 30 symbols")]
        [MinLength(2, ErrorMessage = "Surname cannot be less than 2 symbols")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Invalid date")]
        public DateTime Birthday { get; set; }
        public bool Sex { get; set; }
    }
}
