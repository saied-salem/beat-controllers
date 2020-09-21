using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beat.Models.Enums;

namespace Beat.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Position Position { get; set; }
    }
}
