using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Agentsvo.Models
{
    public class PhoneContact
    {
        [Required(ErrorMessage = "Пожалуйста, введите Id агентства")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите имя покупателя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите фамилию риэлтора")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите дату сделки")]
        public DateTime BirthDay { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите услугу")]
        public string Usluga { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите номер телефона")]
        public string PhoneNumber { get; set; }
    }
}