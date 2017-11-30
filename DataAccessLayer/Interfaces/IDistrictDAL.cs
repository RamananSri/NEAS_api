using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IDistrictDAL
    {
        List<District> GetAll();
        District GetById(int id);
        void Delete(int id);
        void Update(int id, District obj);
        void Create(District obj);
    }
}
