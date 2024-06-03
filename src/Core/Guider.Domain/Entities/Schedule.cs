﻿namespace Guider.Domain.Entities
{
    public class Schedule
    {
        public DateTime Date { get; set; }
        public int ConsultantId { get; set; }
        public float Timespan { get; set; }

        public Consultant Consultant { get; set; }
    }
}