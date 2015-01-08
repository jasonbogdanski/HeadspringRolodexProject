using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadSpringRolodexProject.Core.Interfaces;
using HeadSpringRolodexProject.Core.Models;
using System.Data.Entity;

namespace HeadSpringRolodexProject.DataAccessLayer.EntityFramework
{
    public class EFLookUpModelRepository: ILookUpModelRepository
    {
        public List<BranchLocationModel> GetAllBranchLocations()
        {
            using (var db = new HeadSpringRolodexProject.DataAccessLayer.EntityFramework.EFEmployeeModelRepository.EmployeeContext())
            {
                return db.BranchLocations.ToList();
            }
        }
    }
}
