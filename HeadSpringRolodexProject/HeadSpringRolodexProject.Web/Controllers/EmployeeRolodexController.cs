using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeadSpringRolodexProject.Core.Interfaces;
using HeadSpringRolodexProject.Web.Models;
using AutoMapper.Mappers;
using AutoMapper.QueryableExtensions;


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
        public ActionResult Index(string search_string)
        {
            var employeeViewModels = _employeeRolodexService.GetEmployeesBySearchString(search_string).AsQueryable().Project().To<EmployeeViewModel>().ToList();
            var employeeRolodexViewModel = new EmployeeRolodexViewModel
            {
                Employees = employeeViewModels
            };
            return View(employeeRolodexViewModel);
        }
    }
}