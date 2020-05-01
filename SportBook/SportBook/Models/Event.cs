﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportBook.Helpers;

namespace SportBook.Models
{
    public partial class Event
    {
        public Event()
        {
            EventInvitation = new HashSet<EventInvitation>();
            Participant = new HashSet<Participant>();
        }

        public int EventId { get; set; }
        [MaxLength(60, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        [RegularExpression(@"[A-Za-z0-9\s?.,!?]+", ErrorMessage = "Allowed letters,digits and ?.!, characters")]
        public string Title { get; set; }
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid number")]
        [DisplayName("Max participants")]
        public int? MaxParticipantAmt { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Start time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        [DateValidator]
        public DateTime? StartTime { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd hh:mm}")]
        [DisplayName("End time")]
        [Required(ErrorMessage = "This field is required")]
        //[GreaterThan("StartTime", ErrorMessage ="End time must be greater than start time")]
        [DateValidator]
        public DateTime? EndTime { get; set; }
        [DisplayName("Private")]
        public bool IsPrivate { get; set; }
        [DisplayName("Team Event")]
        public bool IsTeamEvent { get; set; }
        [DisplayName("Owner")]
        public int FkOwner { get; set; }
        [DisplayName("Location")]
        public int? FkLocation { get; set; }
        [DisplayName("Game Type")]
        public int FkGameType { get; set; }
        [DisplayName("Game Type")]
        public virtual GameType FkGameTypeNavigation { get; set; }
        [DisplayName("Location")]
        public virtual Location FkLocationNavigation { get; set; }
        [DisplayName("Owner")]
        public virtual User FkOwnerNavigation { get; set; }
        public virtual ICollection<EventInvitation> EventInvitation { get; set; }
        public virtual ICollection<Participant> Participant { get; set; }
    }
}