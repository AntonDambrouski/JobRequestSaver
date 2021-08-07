using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboutFindingJob.Models
{
    public class JobRequest
    {
        public int Id { get; set; }
        public string NameOfCompany { get; set; }
        public DateTime DateOfSendingCV { get; set; }
        public DateTime DateOfResponse { get; set; }
        public bool isGetInterview { get; set; }
        public string About { get; set; }
    }
}
