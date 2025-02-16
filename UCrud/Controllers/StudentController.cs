using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UCrud.Data;
using UCrud.Models;
using UCrud.Models.Entities;

namespace UCrud.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Add Student
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: Add Student
        [HttpPost]
        public async Task<IActionResult> Add(AddViewModel viewModel)
        {
            // Save the uploaded image
            string imagePath = await SaveImageAsync(viewModel.ImageFile);

            var student = new Student
            {
                Id = Guid.NewGuid(), // ✅ Ensure ID is set
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Course = viewModel.Course,
                ImagePath = imagePath, // ✅ Corrected image assignment
                Semester1 = viewModel.Semester1,
                Semester2 = viewModel.Semester2,
                Semester3 = viewModel.Semester3,
                Semester4 = viewModel.Semester4,
                Semester5 = viewModel.Semester5,
                Semester6 = viewModel.Semester6,
                Semester7 = viewModel.Semester7,
                Semester8=viewModel.Semester8
            };

            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("List");
        }

        // Image Upload Helper Method
        private async Task<string> SaveImageAsync(IFormFile image)
        {
            if (image == null || image.Length == 0)
                return null;

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return "/Images/" + uniqueFileName;
        }

        // GET: List Students
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await _dbContext.Students.ToListAsync();
            return View(students);
        }

        // GET: Edit Student
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            var viewModel = new Student
            {
                Name = student.Name,
                Email = student.Email,
                Phone = student.Phone,
                Course = student.Course,
                ImagePath = student.ImagePath, // ✅ Show existing image
                Semester1 = student.Semester1,
                Semester2 = student.Semester2,
                Semester3 = student.Semester3,
                Semester4 = student.Semester4,
                Semester5 = student.Semester5,
                Semester6 = student.Semester6,
                Semester7 = student.Semester7,
                Semester8 = student.Semester8
            };

            return View(viewModel);
        }

        // POST: Edit Student
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Student viewModel)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // ✅ Update student details
            student.Name = viewModel.Name;
            student.Email = viewModel.Email;
            student.Phone = viewModel.Phone;
            student.Course = viewModel.Course;
            student.Semester1 = viewModel.Semester1;
            student.Semester2 = viewModel.Semester2;
            student.Semester3 = viewModel.Semester3;
            student.Semester4 = viewModel.Semester4;
            student.Semester5 = viewModel.Semester5;
            student.Semester6 = viewModel.Semester6;
            student.Semester7 = viewModel.Semester7;
            student.Semester8 = viewModel.Semester8;

            // ✅ Handle Image Update
            if (viewModel.ImageFile != null)
            {
                student.ImagePath = await SaveImageAsync(viewModel.ImageFile);
            }

            await _dbContext.SaveChangesAsync();
            return RedirectToAction("List");
        }

        // POST: Delete Student
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List");
        }

        // Admin Dashboard
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserRole") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // Student Dashboard
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserRole") != "Student")
            {
                return RedirectToAction("Login", "Account");
            }

            string email = HttpContext.Session.GetString("UserEmail");
            var student = _dbContext.Students.FirstOrDefault(s => s.Email == email);

            if (student == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(student);
        }
    }
}
