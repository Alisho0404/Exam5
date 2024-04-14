using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.GroupDTO
{
    public class UpdateGroupDTO
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public required string GroupNick { get; set; }
        public int ChallengeId { get; set; }
        public bool NeededMember { get; set; }

        [Required, MaxLength(80)]
        public required string TeamSlogan { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
