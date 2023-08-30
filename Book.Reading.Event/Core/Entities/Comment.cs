using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Book.Reading.Event.Base;

namespace Book.Reading.Event.Core.Entities
{
    public class Comment : Entity
    {
        [ForeignKey("Event1")]
        public int EventId { get; set; }
        [Required(ErrorMessage = "Please write a comment before posting")]
        public string comment { get; set; }
        public DateTime timestamp { get; set; }
        public Event1 _event { get; set; }
        public Comment()
        {
            timestamp = DateTime.Now;
        }
    }
}
