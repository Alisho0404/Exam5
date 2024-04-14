using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.ParticipantDTO
{
    public class UpdateParticipantDTO
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(60)]
        public required string FullName { get; set; }

        [MaxLength(60)]
        public string? Email { get; set; }

        [Required, MinLength(20)]
        public required string Phone { get; set; }

        [Required, MaxLength(60)]
        public required string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public int GroupId { get; set; }
        public int LocationId { get; set; }
    }
}
