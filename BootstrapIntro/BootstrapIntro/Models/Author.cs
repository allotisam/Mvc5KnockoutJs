using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootstrapIntro.Models
{
    public class Author
    {
        [JsonProperty(PropertyName ="id")]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Please Enter First Name.")]
        [JsonProperty(PropertyName ="firstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Please Enter Last Name.")]
        [JsonProperty(PropertyName ="lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName ="biography")]
        public string Biography { get; set; }

        [JsonProperty(PropertyName ="books")]
        public virtual ICollection<Book> Books { get; set; }
    }
}