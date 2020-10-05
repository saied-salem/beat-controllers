using Beat.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beat.Interfaces
{
    public interface IPartner
    {
        List<Partner> GetAll();
        Partner GetById(Guid id);
        bool AddPartner(Partner p);
       void  AddListOfPartner(List<Partner> list);
        void RemoveListOfPartner(List<Partner> list);
        bool RemovePartnerById(Guid id);
        void RemovePartner(Partner partner);
        String GetNameById(Guid id);
        String GetWebSiteById(Guid id);
        String GetContactNumberById(Guid id);
        String GetContactPersonById(Guid id);
        void UpdatePartnerInformation(Partner p); //??????????
    }
}
