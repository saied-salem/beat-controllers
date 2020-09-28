using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beat.Model;

namespace Beat.Interfaces
{
    public interface IMemberService
    {
        List<Member> GetAll();
        Member GetById(Guid id);
    }
}
