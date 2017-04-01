using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeadSpringRolodexProject.Core.Interfaces;
using HeadSpringRolodexProject.Web.Models;
using HeadSpringRolodexProject.Core.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;


namespace HeadSpringRolodexProject.Web.Controllers
{
    public class EmployeeRolodexController : Controller
    {
        private readonly IEmployeeModelRepository _employeeRolodexService;
        private readonly ILookUpModelRepository _lookUpModelService;
        private ApplicationUserManager _userManager;

        public EmployeeRolodexController(IEmployeeModelRepository employeeRolodexService, ILookUpModelRepository lookUpModelService)
        {
            _employeeRolodexService = employeeRolodexService;
            _lookUpModelService = lookUpModelService;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: EmployeeRolodex
        [Authorize]
        public ActionResult Index()
        {
            var user = UserManager.FindByName(HttpContext.User.Identity.Name);
            ViewBag.IsHR = UserManager.IsInRole(user.Id, "HR");

            return View(new EmployeeRolodexViewModel());
        }

        public ActionResult Search(string search_string)
        {

            var user = UserManager.FindByName(HttpContext.User.Identity.Name);
            ViewBag.IsHR = UserManager.IsInRole(user.Id, "HR");

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

        [Authorize(Roles = "HR")]
        public ActionResult Create()
        {
            var employeeViewModel = EmployeeViewModel.Create(_lookUpModelService.GetAllBranchLocations());

            return View(employeeViewModel);
        }

        [HttpPost]
        [Authorize(Roles="HR")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "PhoneNumberId")] EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = EmployeeViewModel.MapFrom(model, _lookUpModelService.GetAllBranchLocations()); 
                _employeeRolodexService.Add(employee);
                _employeeRolodexService.Save();
                return RedirectToAction("Index", "EmployeeRolodex");
            }

            model.BranchLocationList = EmployeeViewModel.MapFrom(_lookUpModelService.GetAllBranchLocations());

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [Authorize(Roles = "HR")]
        public ActionResult Edit(int employeeId)
        {
            var employee = _employeeRolodexService.GetById(employeeId);
            var employeeViewModel = EmployeeViewModel.MapFrom(employee, _lookUpModelService.GetAllBranchLocations());

            return View(employeeViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "HR")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel model)
        {
            // do not need to call update on the rolodex repo because EF tracks the changes
            if (ModelState.IsValid)
            {
                var existingEmployee =_employeeRolodexService.GetById(model.EmployeeId);
                var employee = EmployeeViewModel.MapFrom(model, existingEmployee, _lookUpModelService.GetAllBranchLocations()); 
                _employeeRolodexService.Save();
                return RedirectToAction("Index", "EmployeeRolodex");
            }

            model.BranchLocationList = EmployeeViewModel.MapFrom(_lookUpModelService.GetAllBranchLocations());

            return View(model);
           
        }

        [Authorize(Roles = "HR")]
        public ActionResult Delete(int employeeId)
        {
            var employee = _employeeRolodexService.GetById(employeeId);
            var employeeViewModel = EmployeeViewModel.MapFrom(employee, _lookUpModelService.GetAllBranchLocations());

            return View(employeeViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "HR")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmployeeViewModel model)
        {
            _employeeRolodexService.Remove(model.EmployeeId);
            _employeeRolodexService.Save();

            return RedirectToAction("Index", "EmployeeRolodex");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }
            }

            base.Dispose(disposing);
        }

    }
}