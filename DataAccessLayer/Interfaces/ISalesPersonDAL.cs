using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ISalesPersonDAL
    {
        List<SalesPerson> getAll();
        SalesPerson getById(int id);
        bool delete(int id);
        bool update(int id, SalesPerson obj);
    }
}
