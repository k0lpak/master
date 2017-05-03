using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TestProject.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The {0} can not be empty")]
        [MaxLength(256, ErrorMessage = "The {0} must be maximum {2} characters long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The {0} can not be empty")]
        [MaxLength(256, ErrorMessage = "The {0} must be maximum {2} characters long")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The {0} can not be empty")]
        public string Email { get; set; }
        
        public Position Position {get;set;}
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Position
    {
        [EnumMember(Value ="PM")]
        PM,
        [EnumMember(Value = "QA")]
        QA,
        [EnumMember(Value = "Developer")]
        Developer,
        [EnumMember(Value = "Other")]
        Other
    }
}