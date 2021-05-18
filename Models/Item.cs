using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogADoc.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public string Status { get; set; }
        public string CurrentHolder { get; set; }
        public DateTime ReturnedOn { get; set; }
        public DateTime DestroyedOn { get; set; }
        public string RequestedBy { get; set; }
        public string RequestReason { get; set; }
    }
}
