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
        private readonly IEmployeeModelRepository _employeeRolodexService;
        private readonly ILookUpModelRepository _lookUpModelService;

        public EmployeeRolodexController(IEmployeeModelRepository employeeRolodexService, ILookUpModelRepository lookUpModelService)
        {
            _employeeRolodexService = employeeRolodexService;
            _lookUpModelService = lookUpModelService;
        }
        // GET: EmployeeRolodex
        public ActionResult Index()
        {
            return View(new EmployeeRolodexViewModel());
        }

        public ActionResult Search(string search_string)
        {
            var employeeViewModels = EmployeeViewModel.MapFrom(_employeeRolodexService.GetEmployeesBySearchString(search_string));
            var employeeRolodexViewModel = new EmployeeRolodexViewModel
            {
                Employees = employeeViewModels
            };

            if (employeeViewModels.Count() == 0)
            {
                employeeRolodexViewModel.SearchMessage = "No Employees Found";
            }
            return View("Index", employeeRolodexViewModel);
        }

        public ActionResult Create()
        {
            var employeeViewModel = EmployeeViewModel.Create(_lookUpModelService.GetAllBranchLocations());

            return View(employeeViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "PhoneNumberId")] EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = EmployeeViewModel.MapFrom(model, _lookUpModelService.GetAllBranchLocations()); 
                _employeeRolodexService.Add(employee);
                return RedirectToAction("Index", "EmployeeRolodex");
            }

            model.BranchLocationList = EmployeeViewModel.MapFrom(_lookUpModelService.GetAllBranchLocations());

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult Edit(int employeeId)
        {
            var employee = _employeeRolodexService.GetById(employeeId);
            var employeeViewModel = EmployeeViewModel.MapFrom(employee, _lookUpModelService.GetAllBranchLocations());

            return View(employeeViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee =_employeeRolodexService.GetById(model.EmployeeId);
                var employee = EmployeeViewModel.MapFrom(model, existingEmployee, _lookUpModelService.GetAllBranchLocations()); 
                _employeeRolodexService.Update(employee);              
                return RedirectToAction("Index", "EmployeeRolodex");
            }

            model.BranchLocationList = EmployeeViewModel.MapFrom(_lookUpModelService.GetAllBranchLocations());

            return View(model);
           
        }

        public ActionResult Delete(int employeeId)
        {
            var employee = _employeeRolodexService.GetById(employeeId);
            var employeeViewModel = EmployeeViewModel.MapFrom(employee, _lookUpModelService.GetAllBranchLocations());

            return View(employeeViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmployeeViewModel model)
        {
            _employeeRolodexService.Remove(model.EmployeeId);

            return RedirectToAction("Index", "EmployeeRolodex");
        }

    }
}