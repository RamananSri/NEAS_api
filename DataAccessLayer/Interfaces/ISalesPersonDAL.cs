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
        void delete(int id);
        void update(SalesPerson obj);

        void create(SalesPerson obj);
    }
}
