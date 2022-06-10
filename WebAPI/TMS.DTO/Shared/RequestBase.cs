using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.DTO.Shared
{
    public class RequestBase
    {
        public string UserID { get; set; }

        public object SearchCriteriaList { get; set; }

        public object Data { get; set; }
    }
}
