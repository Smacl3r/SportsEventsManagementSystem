﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportBook.Models
{
    public partial class Location
    {
        public Location()
        {
            Event = new HashSet<Event>();
        }

        public int LocationId { get; set; }
        //[RegularExpression(@"-?[0-9]+\.[0-9]*", ErrorMessage = "Incorrect format. Example: 54.231546")]
        [DisplayFormat(DataFormatString = "{0:F6}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "This field is required")]
        public decimal? Latitude { get; set; }
        [DisplayFormat(DataFormatString = "{0:F6}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "This field is required")]
        public decimal? Longitude { get; set; }
        [MaxLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Address { get; set; }
        [DisplayName("City")]
        public int FkCity { get; set; }
        [DisplayName("Game Type")]
        public int FkGameType { get; set; }
        [DisplayName("City")]
        public virtual City FkCityNavigation { get; set; }
        [DisplayName("Game Type")]      // ?
        public virtual GameType FkGameTypeNavigation { get; set; }
        public virtual ICollection<Event> Event { get; set; }
    }
}
