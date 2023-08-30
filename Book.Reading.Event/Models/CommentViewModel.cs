using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Book.Reading.Event.Models
{
    public class CommentViewModel
    {
        [ForeignKey("Event")]
        public int EventId { get; set; }
        [Required(ErrorMessage = "Please write a comment before posting")]
        public string comment { get; set; }
        public DateTime timestamp { get; set; }
        public EventViewModel _event { get; set; }
        public CommentViewModel()
        {
            timestamp = DateTime.Now;
        }
    }
}
