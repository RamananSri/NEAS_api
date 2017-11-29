using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DistrictBLL : IDistrictBLL
    {
        IDistrictDAL districtDAL;

        // Constructor dependency injection (use IoC containers instead)
        public DistrictBLL(IDistrictDAL districtDAL)
        {
            this.districtDAL = districtDAL;
        }
        public DistrictBLL()
        {
            districtDAL = new DistrictDAL();
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<District> getAll()
        {
            List<District> districts = districtDAL.getAll();
            return districts;
        }

        public District getById(int id)
        {
            throw new NotImplementedException();
        }

        public bool update(int id, District obj)
        {
            throw new NotImplementedException();
        }
    }
}
