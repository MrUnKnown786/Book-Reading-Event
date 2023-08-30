using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Book.Reading.Event.Application.Models
{
    public class CommentModel : BaseModel
    {
        [ForeignKey("Event")]
        public int EventId { get; set; }
        [Required(ErrorMessage = "Please write a comment before posting")]
        public string comment { get; set; }
        public DateTime timestamp { get; set; }
        public EventModel _event { get; set; }
        public CommentModel()
        {
            timestamp = DateTime.Now;
        }
    }
}
