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
        private HeadSpringRolodexProject.DataAccessLayer.EntityFramework.EFEmployeeModelRepository.EmployeeContext _context;

        public EFLookUpModelRepository(HeadSpringRolodexProject.DataAccessLayer.EntityFramework.EFEmployeeModelRepository.EmployeeContext context)
        {
            _context = context;
        }

        public List<BranchLocationModel> GetAllBranchLocations()
        {
            return _context.BranchLocations.ToList();
        }
    }
}
