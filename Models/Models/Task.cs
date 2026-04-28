using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Models
{
  public class Task
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)] //Only Date
        [Required]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)] //Only Date
        [Required]
        public DateTime EndDate { get; set; }
        [DataType(DataType.Date)] //Only Date
        [Required]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Date)] //Only Date
        [Required]
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public decimal EstimatedHours { get; set; }

        public int ? statusId { get; set; }
        public Status Status { get; set; }

        public string ?UserId { get; set; }
        public ApplicationUser User { get; set; }

        public String ?CreatedByUserId { get; set; }
        public ApplicationUser CreatedByUser { get; set; }

        public String ?ModifiedByUserId { get; set; }
        public ApplicationUser ModifiedByUser { get; set; }

        public int ?EpicId { get; set; }
        public Epic Epic { get; set; }


    }
}
