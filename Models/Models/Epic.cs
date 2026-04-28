using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Models
{
    public class Epic
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50),MinLength(5)]
        [Required]
        public string Title {  get; set; }
        [DataType(DataType.Date)] //Only Date
        [Required]
        public DateTime StartDate {  get; set; }
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

        public int ?statusId {  get; set; }
        public Status Status { get; set; }

        public String ?CreatedByUserId {  get; set; }
        public ApplicationUser CreatedByUser { get; set; }

        public String ?ModifiedByUserId { get; set; }
        public ApplicationUser ModifiedByUser { get; set; }

        public int ?ProjectId {  get; set; }
        public Project Project { get; set; }








    }
}
