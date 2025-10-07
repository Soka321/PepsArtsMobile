using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepsArts_Mobile.Models
{
   public  class Exhibition_Registration
    {

        public int id { get; set; }
        public int exhibition_id { get; set; }
        [ForeignKey("exhibition_id")]
        public Exhibition exhibition { get; set; }
      

        public int user_id { get; set; }//this is the visitor Id
        [ForeignKey("user_id")]
        public User user { get; set; }

        public DateTime registration_date { get; set; } = DateTime.Now;
        public int number_of_attendees { get; set; }
    }
}
