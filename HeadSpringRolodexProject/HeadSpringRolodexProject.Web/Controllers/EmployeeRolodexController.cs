using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeadSpringRolodexProject.Core.Interfaces;

namespace HeadSpringRolodexProject.Web.Controllers
{
    public class EmployeeRolodexController : Controller
    {
        private readonly IEmployeeRolodexService _employeeRolodexService;

        public EmployeeRolodexController(IEmployeeRolodexService employeeRolodexService)
        {
            _employeeRolodexService = employeeRolodexService;
        }
        // GET: EmployeeRolodex
        public ActionResult Index()
        {
            return View();
        }
    }
}