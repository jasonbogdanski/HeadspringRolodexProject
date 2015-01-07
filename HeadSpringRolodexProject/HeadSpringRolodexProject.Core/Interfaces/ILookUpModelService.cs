using System;
namespace HeadSpringRolodexProject.Core.Interfaces
{
    public interface ILookUpModelService
    {
        System.Collections.Generic.List<HeadSpringRolodexProject.Core.Models.BranchLocationModel> GetAllBranchLocations();
    }
}
