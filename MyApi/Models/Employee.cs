using MyApi.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public Gender? Gender { get; set; }
    }
}
