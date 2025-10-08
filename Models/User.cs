using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepsArts_Mobile.Models
{
    public class User
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Please provide your Name")] //handling errors when no input
        public required string first_name { get; set; }
        [Required(ErrorMessage = "Please provide your Lastname")] //handling errors when no input
        public required string last_name { get; set; }
        [Required(ErrorMessage = "Please provide your Gender")] //handling errors when no input
        public required string gender { get; set; }
        public int age { get; set; }
        [Required(ErrorMessage = "Please provide your email")] //handling errors when no input
        [EmailAddress(ErrorMessage = "Please provide valid email address")]
        public required string email { get; set; }
        [Required(ErrorMessage = "Please provide your Password")] //handling errors when no input
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Please provide your Password with minimum 8 characters")] //handling errors when no input
        [DataType(DataType.Password)]
        public required string password { get; set; }
        [Required(ErrorMessage = "Please provide your phone number")] //handling errors when no input
        public int phone_number { get; set; }

        public required string role { get; set; }
        public DateTime date_created { get; set; } = DateTime.Now;

    }
}
