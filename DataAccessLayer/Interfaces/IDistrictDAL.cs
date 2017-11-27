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
        List<District> getAll();
        District getById(int id);
        bool delete(int id);
        bool update(int id, District obj);
    }
}
