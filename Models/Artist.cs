using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepsArts_Mobile.Models
{
   public class Artist
    {
        public int Id { get; set; }
        public string name { get; set; }
        [Required(ErrorMessage = "Please provide Surname for Artist")] //handling errors when no input

        public string surname { get; set; }
        [Required(ErrorMessage = "Please provide Biography for Artist")] //handling errors when no input

        public string biography { get; set; }
        [Required(ErrorMessage = "Please provide email for Artist")] //handling errors when no input
        [EmailAddress(ErrorMessage = "Please provide valid e-mail address")]

        public string email { get; set; }
        [Required(ErrorMessage = "Please provide phone number for Artist")] //handling errors when no input

        public int phone_number { get; set; }
        [Required(ErrorMessage = "Please provide country for Artist")] //handling errors when no input

        public string country { get; set; }
        [Required(ErrorMessage = "Please provide City for Artist")] //handling errors when no input

        public string city { get; set; }
        [Required(ErrorMessage = "Please provide date of creation for Artist")] //handling errors when no input


        public DateTime date_created { get; set; }
    }
}
