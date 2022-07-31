using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneWordTvBackend.Helpers
{
    public class ResponseMessage <T>
    {
        public bool status { get; set; } = false;
        public T data { get; set; }
        public string message { get; set; }
    }
}
