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


namespace UserCVuploader.Controllers
{
    public class CVController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CVController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var cv = new CV
                    {
                        UserId = _userManager.GetUserId(User),
                        /*FileName = file.FileName,
                        Content = memoryStream.ToArray(),
                        UploadedOn = DateTime.UtcNow*/
                    };
                    _context.CVs.Add(cv);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction("ViewCV");
        }

        /*[HttpGet]
        public async Task<IActionResult> ViewCV()
        {
            var userId = _userManager.GetUserId(User);
            var cv = await _context.CVs.FirstOrDefaultAsync(c => c.UserId == userId);
            if (cv == null)
            {
                return NotFound();
            }
            return View(cv);
        }*/
    }
}
