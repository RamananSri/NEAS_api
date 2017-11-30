using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IStoreDAL
    {
        List<Store> getAll();
        Store getById(int id);
        void delete(int id);
        void update(Store obj);
    }
}
