﻿using CinemaTicketBooking.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace FilmTicketBooking.Models
{
    public class Ticket : BaseEntity
    {


        [Required]
        [Range(0, 11)]
        public int HallNumber { get; set; }

        [Range(0, 50)]
        public int Seat { get; set; }

        [Range(0, 11)]
        public int Row { get; set; }

        [StringLength(10)]
        public string HourAndMinute { get; set; }

       public Film Film { get; set; }

       public Guid FilmId { get; set; }

        public Client Client { get; set; }

    }
}
