using System;
using System.ComponentModel.DataAnnotations;


namespace SofETest.WebAPI.Models
{
    public class Contributor
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "Name was not found in values")]
        [StringLength(100, ErrorMessage = "name must not be more than 100 characters long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email was not found in values")]
        [StringLength(50, ErrorMessage = "Email must not be more than 50 characters long")]
        public string Email { get; set; }

        [Range(1000000000, 9999999999, ErrorMessage = "Phone must be an integer grater or equal to 1000000000 and no bigger than 9999999999")]
        public long Phone { get; set; }

        public Contributor()
        {
            this.Id = 0;
            this.Name = string.Empty;
            this.Email = string.Empty;
            this.Phone = 0;
        }

        public override string ToString()
        {
            return " { name: " + Name + ", email: " + Email + " }";
        }
    }
}