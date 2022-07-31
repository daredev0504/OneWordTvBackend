using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneWordTvBackend.Models.Dto
{
    public class OneWordProgramTvDTO
    {
        public int day { get; set; }
        public DateTime hour { get; set; }
        public string title { get; set; }
    }
}
