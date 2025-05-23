﻿namespace WebAPI.Entities
{
    public class Reservation
    {
        public int ReservationId{ get; set; }
        public string NameSurname{ get; set; }
        public string Email{ get; set; }
        public string Phone{ get; set; }
        public DateTime ReservationDate{ get; set; }
        public string Hour{ get; set; }
        public int CountOfPeople{ get; set; }
        public string Message{ get; set; }
        public string ReservationStatus{ get; set; }
    }
}
