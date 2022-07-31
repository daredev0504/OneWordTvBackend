using OneWordTvBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneWordTvBackend.Models
{
    public class OneWordTvProgram : BaseEntity
    {
        public DateTime Hour { get; set; }
        public string Title { get; set; }
        public DayConstants Day { get; set; }
    }
}
