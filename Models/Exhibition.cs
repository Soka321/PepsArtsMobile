using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PepsArts_Mobile.Models
{
    public class Exhibition
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide Title for Exhibition")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        [JsonPropertyName("start_date")]
        public DateTime Start_Date { get; set; }
        [DataType(DataType.DateTime)]
        [JsonPropertyName("end_date")]
        public DateTime End_Date { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please provide Status for Exhibition")]
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("user_id")]
        public int User_Id { get; set; }
        //Created by which owner
        [ForeignKey("User_Id")]
        public User user { get; set; }
    }
}
