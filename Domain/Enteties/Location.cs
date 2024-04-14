using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public required string Name { get; set; }

        [Required, MaxLength(100)]
        public required string Description { get; set; }

        public Participant? Participant { get; set; } 


        //public int ParticipantId { get; set; }
    }
}
