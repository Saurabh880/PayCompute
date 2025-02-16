using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Paycompute.Entity;
using Paycompute.Models;
using Paycompute.Services;

namespace Paycompute.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment hostingEnvironment)
        {
            _employeeService = employeeService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index() 
        {
            var employeeList = _employeeService.GetAllEmployees().Select(employeeList => new EmployeeIndexViewModel
            {
                Id = employeeList.Id,
                FullName = employeeList.FullName,
                EmployeeNo = employeeList.EmployeeNo,
                ImageURL = employeeList.ImageURL,
                DateJoined = employeeList.DateJoined,
                Gender = employeeList.Gender,
                City = employeeList.City,
                Designation = employeeList.Designation,
            }).ToList();
            return View(employeeList);
        }
        [HttpGet]

        public IActionResult Create()
        {
            //Here we want to render the view model, uses to get data and render our view model
            var model = new EmployeeCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //prevents cross-site request forgery attacks
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            //Used to send data to server to create or update resource
            if (ModelState.IsValid) {
                var employee = new Employee
                {
                    Id = model.Id,
                    FullName = model.FullName,
                    EmployeeNo = model.EmployeeNo,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    Email = model.Email,
                    DOB = model.DOB,
                    DateJoined = model.DateJoined,
                    NationalInsuranceNo = model.NationalInsuranceNo,
                    PaymentMethod = model.PaymentMethod,
                    StudentLoan = model.StudentLoan,
                    UnionMember = model.UnionMember,
                    Address = model.Address,
                    City = model.City,
                    Designation = model.Designation,
                    Phone = model.Phone,
                    Postcode = model.Postcode,
                    
                };
                if (model.ImageURL != null && model.ImageURL.Length > 0)
                {
                    var uploadDirectory = @"images/employee";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageURL.FileName);
                    var extension = Path.GetExtension(fileName);

                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssff") + fileName + extension;
                    var path = Path.Combine(uploadDirectory, uploadDirectory,fileName);
                    await model.ImageURL.CopyToAsync(new FileStream(path,FileMode.Create));
                    //below is the URL we will save in database
                    employee.ImageURL = "/" + uploadDirectory + "/" + fileName;
                }
                await _employeeService.CreateAsync(employee);
                //return to Index
                return RedirectToAction(nameof(Index));
            }
            else { 
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //we retrieve the Employee by ID and then we pass the employee to our view model, which will rebder to our view
            var employee = _employeeService.GetById(id);
            if (employee == null) {
                return NotFound();
            }
            var model = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                
                EmployeeNo = employee.EmployeeNo,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                DateJoined = employee.DateJoined,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                PaymentMethod = employee.PaymentMethod,
                StudentLoan = employee.StudentLoan,
                UnionMember = employee.UnionMember,
                Address = employee.Address,
                City = employee.City,
                Designation = employee.Designation,
                Phone = employee.Phone,
                Postcode = employee.Postcode,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeEditViewModel employeeEditView) {

            if (!ModelState.IsValid) {
                var employee = _employeeService.GetById(employeeEditView.Id);

                if (employee == null)
                {
                    return NotFound();
                }
                else
                {
                    employee.EmployeeNo = employeeEditView.EmployeeNo;
                    employee.FirstName = employeeEditView.FirstName;
                    employee.MiddleName = employeeEditView.MiddleName;
                    employee.LastName = employeeEditView.LastName;
                    employee.DOB = employeeEditView.DOB;
                    employee.DateJoined = employeeEditView.DateJoined;
                    employee.Designation = employeeEditView.Designation;
                    employee.NationalInsuranceNo = employeeEditView.NationalInsuranceNo;
                    employee.Email = employeeEditView.Email;
                    employee.Phone = employeeEditView.Phone;
                    employee.Gender = employeeEditView.Gender;
                    employee.Address = employeeEditView.Address;
                    employee.City = employeeEditView.City;
                    employee.PaymentMethod = employeeEditView.PaymentMethod;
                    employee.StudentLoan = employeeEditView.StudentLoan;
                    employee.UnionMember = employeeEditView.UnionMember;
                    employee.Postcode = employeeEditView.Postcode;
                    if (employeeEditView.ImageURL != null && employeeEditView.ImageURL.Length > 0)
                    {
                        var uploadDirectory = @"images/employee";
                        var fileName = Path.GetFileNameWithoutExtension(employeeEditView.ImageURL.FileName);
                        var extension = Path.GetExtension(fileName);

                        var webRootPath = _hostingEnvironment.WebRootPath;
                        fileName = DateTime.UtcNow.ToString("yymmssff") + fileName + extension;
                        var path = Path.Combine(uploadDirectory, uploadDirectory, fileName);
                        await employeeEditView.ImageURL.CopyToAsync(new FileStream(path, FileMode.Create));
                        //below is the URL we will save in database
                        employee.ImageURL = "/" + uploadDirectory + "/" + fileName;
                    }
                    await _employeeService.UpdateAsync(employee);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        public IActionResult Details(int EmployeeId)
        {
            var employee = _employeeService.GetById(EmployeeId);
            if (employee == null)
            {
                return View();
            }
            EmployeeDetailViewModel employeeDetailView = new EmployeeDetailViewModel()
            {
                Id = EmployeeId,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                Designation = employee.Designation,
                Email = employee.Email,
                DOB = employee.DOB,
                Phone = employee.Phone,
                DateJoined = employee.DateJoined,
                PaymentMethod = employee.PaymentMethod,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                UnionMember = employee.UnionMember,
                StudentLoan = employee.StudentLoan,
                Address = employee.Address,
                City = employee.City,
                Postcode = employee.Postcode,
                ImageURL = employee.ImageURL,

            };

            return View(employeeDetailView);
        }

        [HttpGet]
        public IActionResult DeleteEmployee(int EmployeeID)
        {
            var employee = _employeeService.GetById(EmployeeID);
            if ( employee == null)
            {
                return NotFound();
            }
            var employeeDeleteView = new EmployeeDeleteViewModel()
            {
                EmployeeId = employee.Id,
                EmployeeName = employee.FullName
            }; 
            return View(employeeDeleteView);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEmployee(EmployeeDeleteViewModel employeeDeleteViewmodel)
        {
            await _employeeService.Delete(employeeDeleteViewmodel.EmployeeId);
            return RedirectToAction(nameof(Index));
        }
    }
}
