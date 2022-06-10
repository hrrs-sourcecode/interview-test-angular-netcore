using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.DTO.Shared
{
    public class EntityBase
    {
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
