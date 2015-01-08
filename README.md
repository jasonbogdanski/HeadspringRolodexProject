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
 
 1. Pull down the source and open the HeadSpringRolodexProject.sln solution in Visual Studio 2013.
 2. In the nuget package manager restore all the solution's packages. **Should be prompted in the nuget console**
 3. Rebuild the solution.
 4. Close and reopen the solution. *Update-Database will not show up in nuget unless this is done*
 5. In the nuget package manager target the HeadSpringRolodexProject.DataAccessLayer project.
    Run: Update-Database
 6. Run the solution.  Starts on the Login page.  
 7. Register an HR user and a Non-HR User
 8. Login with the HR user and the application is redirected to the Employee Rolodex Page. The initial employee rolodex
    does not have any employees.  The HR user can create/update/delete employees.
	*Going to add a seed script for employees at a later time*
9.  Log out and login with the non-hr user. Perform a search for employees created by the HR user.
 
