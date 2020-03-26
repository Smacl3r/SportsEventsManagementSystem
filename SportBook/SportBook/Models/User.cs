﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace SportBook.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [StringLength(35, MinimumLength = 3)]
        [Required]
        public string Nickname { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 7)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        [Required]
        public string Mail { get; set; }
    }
}