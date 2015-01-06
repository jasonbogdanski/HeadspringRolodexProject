using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeadSpringRolodexProject.Core.Interfaces;
using HeadSpringRolodexProject.Web.Models;
using HeadSpringRolodexProject.Core.Models;
using AutoMapper;
using AutoMapper.Mappers;
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;


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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult Edit(int employeeId)
        {
            var employee = _employeeRolodexService.GetById(employeeId);
            var employeeViewModel = Mapper.Map<EmployeeViewModel>(employee);

            return View(employeeViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {

            }

            var employee = Mapper.Map<EmployeeModel>(model);

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}