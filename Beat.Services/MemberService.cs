using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beat.Data;
using Beat.Model;
using Beat.Interfaces;

namespace Beat.Services
{
    public class MemberService: IMemberService
    {
        private BeatContext db;

        public MemberService()
        {
            db = new BeatContext();
        }

        public List<Member> GetAll()
        {
            return db.Members.ToList();
        }

        public Member GetById(int id)
        {
            return db.Members.FirstOrDefault(m => m.Id == id);
        }
    }
}
