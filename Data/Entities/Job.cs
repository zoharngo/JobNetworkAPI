using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobNetworkAPI.Data.Entities
{
    public class Job
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JobId { get; set; }
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string JobLocation { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Discirption { get; set; }
        public int JobTitleId { get; set; }
        [ForeignKey("JobTitleId")]
        public JobTitle JobTitle { get; set; }
    }
}
