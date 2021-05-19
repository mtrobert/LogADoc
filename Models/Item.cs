using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogADoc.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please provide the name.")]
        [DisplayName("Item Name")]
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Please set the current holder.")]
        [DisplayName("Current Holder")]
        public string CurrentHolder { get; set; }
        public DateTime ReturnedOn { get; set; }
        public DateTime DestroyedOn { get; set; }
        public string RequestedBy { get; set; }
        public string RequestReason { get; set; }
    }
}
