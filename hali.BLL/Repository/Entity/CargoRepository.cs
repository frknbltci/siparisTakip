using hali.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hali.BLL.Repository.Entity
{
    public class CargoRepository: Base.BaseRepository<Cargo>
    {
        public void Update(Cargo cargo)
        {

            Cargo update = Find((int)cargo.ID);
            update.CargoName = cargo.CargoName;
            Save();

        }

        public void UpdateIsActive(int id)
        {
            Cargo update = Find((int)id);
            update.IsActive = false;
            Save();
        }
        public void UpdateActive(int id)
        {
            Cargo update = Find((int)id);
            update.IsActive = true;
            Save();
        }

    }
}
