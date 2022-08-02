using OneWordTvBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneWordTvBackend.Models.Dto
{
    public class OneWordProgramTvUpdateDTO
    {
        public string Id { get; set; }
        public string Day { get; set; }
        public string hour { get; set; }
        public string title { get; set; }
    }

    public class OneWordProgramTvCreateDTO
    {
        public int Day { get; set; }
        public string hour { get; set; }
        public string title { get; set; }
    }
}
