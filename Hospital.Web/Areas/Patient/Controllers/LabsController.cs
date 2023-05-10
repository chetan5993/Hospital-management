using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hospital.Web.Areas.Patient.Controllers
{
    [Area("Patient")]



    public class LabsController : Controller
    {
        private ILabServices _Lab;
        private IApplicationUserService _ApplicationUser;


        public LabsController(ILabServices Lab, IApplicationUserService applicationUser)
        {
            _Lab = Lab;
            _ApplicationUser = applicationUser;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_Lab.GetAll(pageNumber, pageSize));
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Patients = new SelectList(_ApplicationUser.GetAll(), "Id", "Name");
            var viewModel = _Lab.GetLabById(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(LabViewModel vm)
        {
            _Lab.UpdateLab(vm);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Patients = new SelectList(_ApplicationUser.GetAll(), "Email", "Name");
            return View();
        }
        [HttpPost]

        public IActionResult Create(LabViewModel vm)
        {
            _Lab.InsertLab(vm);
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            _Lab.DeleteLab(id);
            return RedirectToAction("Index");
        }
    }
}
    
