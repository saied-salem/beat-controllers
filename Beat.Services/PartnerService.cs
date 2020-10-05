using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beat.Data;
using Beat.Model;
using Beat.Interfaces;

namespace Beat.Services
{

    public class PartnerService : IPartner
    {
        private BeatContext db;
        public PartnerService()
        {
            db = new BeatContext();
        }
        public List<Partner> GetAll()
        {
             return db.Partners.ToList();
       
        }

        public Partner GetById(Guid id)
        {
            var ppppp= db.Partners.FirstOrDefault(p => p.Id == id);


            return ppppp;
        
        }

        public bool AddPartner(Partner p)
        {
              var ppp = GetById(p.Id);
             if (ppp != null)
             {
                  return false;
             }

              else
             {
                 db.Partners.Add(p); 
                 db.SaveChanges();
                 return true;
             }

        }

        public void AddListOfPartner(List<Partner> list)
        {
            foreach (var p in list)
            {
                if (db.Partners.Contains(p))
                {
                    continue;
                }
                else
                {
                    db.Partners.Add(p);
                }
                db.SaveChanges();
            }

        }

        public void  RemoveListOfPartner(List<Partner> list)
        {
           
            db.Partners.RemoveRange(list);
            db.SaveChanges();
        }
        public bool RemovePartnerById(Guid id)
        {
            var partner = this.GetById(id);
            if (this.GetById(id) != null) // or we can use -------        db.Partners.Find(this.GetById(id));
            {
                db.Partners.Remove(partner);

                return true;
            }
            else
                return false;

        }

        public void RemovePartner(Partner partner)
        {
            
                db.Partners.Remove(db.Partners.Find(partner.Id));
                db.SaveChanges();

        }
         
        public String GetNameById(Guid id)
        {
            
            return db.Partners.Find(id).Name;
        }
        public String GetWebSiteById(Guid id)
        {
           
            return db.Partners.Find(id).Website;
        }
        public String GetContactNumberById(Guid id)
        {
            
           return db.Partners.Find(id).ContactNumber;
        }
        public String GetContactPersonById(Guid id)
        {

            return db.Partners.Find(id).ContactPerson;
        }

        public void UpdatePartnerInformation(Partner p) //???????????????
        {
            db.Partners.AddOrUpdate(p);
            db.SaveChanges();
        }
    }
}
