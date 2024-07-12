using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserCVuploader.Data;
using UserCVuploader.Models;
using System.IO;
//using OfficeOpenXml;
using System.Data;
//using System.Linq;

namespace UserCVuploader.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserProfileController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult UploadCV()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadCV(UploadCVViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var user = await _userManager.FindByIdAsync(userId);

                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", userId + "_" + model.CV.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.CV.CopyToAsync(fileStream);
                }

                var userProfile = new UserProfile
                {
                    UserId = userId,
                    CVFilePath = filePath
                };

                _context.UserProfiles.Add(userProfile);
                await _context.SaveChangesAsync();

                return RedirectToAction("ViewCV");
            }
            return View(model);
        }
    }
}
