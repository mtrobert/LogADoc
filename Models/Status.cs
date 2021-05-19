using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogADoc.Models
{
    public class Status
    {
        [Key]
        [DisplayName("Name")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Added By")]
        public string AddedBy { get; set; }
    }
}
