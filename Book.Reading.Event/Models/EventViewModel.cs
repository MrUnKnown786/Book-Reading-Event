using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book.Reading.Event.Models
{
    public class EventViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Please Enter title of the book")]
        [Display(Name = "Title of the Book")]
        public string title { get; set; }

        [Required(ErrorMessage = "Please Enter the Event Date")]
        [Display(Name = "Event Date")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }

        [Required(ErrorMessage = "Please Enter the Start Time")]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public DateTime starttime { get; set; }

        [Required(ErrorMessage = "Please Enter the Venue")]
        [Display(Name = "Venue")]
        public string location { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Range(1, 4, ErrorMessage = "Duration Should be 1-4 hours only")]
        public int? duration { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        [Display(Name = "Organiser")]
        public string organiser { get; set; }

        [Display(Name = "Type of Event")]
        public string eventType { get; set; }

        [Display(Name = "Invite People")]
        public string invites { get; set; }


        [ForeignKey("EventId")]
        public ICollection<CommentViewModel> comments { get; set; }
    }
}
