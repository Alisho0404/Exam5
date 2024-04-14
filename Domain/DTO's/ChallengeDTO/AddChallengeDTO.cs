using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO_s.ChallengeDTO
{
    public class AddChallengeDTO
    {

        [Required, MaxLength(50)]
        public required string Title { get; set; }

        [Required, MaxLength(100)]
        public required string Description { get; set; }
    }
}
