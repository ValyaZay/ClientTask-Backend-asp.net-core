using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTaskWebAPI_v1.DTOandViewModels
{
    public class UpdateTaskViewModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string ClientAddress { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int ClientId { get; set; }
    }
}
