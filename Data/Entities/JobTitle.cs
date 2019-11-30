using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobNetworkAPI.Data.Entities
{
    public class JobTitle
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JobTitleId { get; set; }
        public string JobTitleText { get; set; }
    }
}
