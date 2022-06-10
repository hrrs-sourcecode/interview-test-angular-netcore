using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.DTO.Shared
{
    public class ResponseBase
    {
        private List<string> _messages = new List<string>();
        public List<string> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }
        public bool IsSuccess { get; set; }

        public object Data { get; set; }
    }
}
