using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class Details
    {
        public long ID { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? PercentCompleteness { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string Status { get; set; }
        public bool IsDelete { get; set; }
    }
}
