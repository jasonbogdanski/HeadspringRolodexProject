using System;
namespace HeadSpringRolodexProject.Core.Interfaces
{
    public interface ILookUpModelRepository
    {
        System.Collections.Generic.List<HeadSpringRolodexProject.Core.Models.BranchLocationModel> GetAllBranchLocations();
    }
}
