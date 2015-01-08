namespace HeadSpringRolodexProject.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using HeadSpringRolodexProject.Core.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<HeadSpringRolodexProject.DataAccessLayer.EntityFramework.EFEmployeeModelRepository.EmployeeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HeadSpringRolodexProject.DataAccessLayer.EntityFramework.EFEmployeeModelRepository.EmployeeContext context)
        {

            IList<BranchLocationModel> branchLocations = new List<BranchLocationModel>();

            branchLocations.Add(new BranchLocationModel() { City = "Austin", State = "TX" });
            branchLocations.Add(new BranchLocationModel() { City = "Denver", State = "CO" });
            branchLocations.Add(new BranchLocationModel() { City = "Wadsworth", State = "OH" });

            foreach (BranchLocationModel branch in branchLocations)
                context.BranchLocations.Add(branch);

            base.Seed(context);

        }
    }
}
