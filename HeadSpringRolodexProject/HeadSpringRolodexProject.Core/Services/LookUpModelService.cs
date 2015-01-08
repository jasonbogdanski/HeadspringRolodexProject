using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadSpringRolodexProject.Core.Models;
using HeadSpringRolodexProject.Core.Interfaces;

namespace HeadSpringRolodexProject.Core.Services
{
    //A service that returns lookup models
    public class LookUpModelService : ILookUpModelRepository
    {
        public List<BranchLocationModel> GetAllBranchLocations()
        {
            var branchLocations = new List<BranchLocationModel>();

            branchLocations.Add(BranchLocationModel.Create(1, "Austin", "TX"));
            branchLocations.Add(BranchLocationModel.Create(2, "Wadsworth", "OH"));
            branchLocations.Add(BranchLocationModel.Create(3, "Denver", "CO"));

            return branchLocations;
        }
    }
}
