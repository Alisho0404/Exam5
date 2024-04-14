using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enteties
{
    public class Participant
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(60)]
        public required string FullName { get; set; }

        [MaxLength(60)]
        public string? Email { get; set; }

        [Required,MinLength(20)]
        public required string Phone { get; set; }

        [Required, MaxLength(60)]
        public required string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public int GroupId { get; set; }
        public int LocationId { get; set; }

        public Location? Location { get; set; }

        public Group? Group { get; set; }
    }
}
