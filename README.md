Headspring Rolodex Project
========================

An internal employee directory so all of our employees can search our database of 30,000 employees.
We want any HR representatives to be able to add/edit/delete employees.
A typical directory entry has the following information:

* Name
* Job Title
* Location
* Email
* Phone Number(s)
 
 ## Installation
 
 Requirements
 * Visual Studio 2013
 
 1. Pull down the source and open the HeadSpringRolodex.sln solution in Visual Studio 2013.
 2. In the nuget package manager restore all the solution's packages. **Should be prompted in the nuget console**
 3. Rebuild the solution.
 4. In the nuget package manager target the HeadSpringRolodexProject.DataAccessLayer project.
    Run: Update-Database
 5. Run the solution.  Starts on the Employee Rolodex page.  The initial employee rolodex does 
	not have any employees.  *Going to add a seed script for employees at a later time*