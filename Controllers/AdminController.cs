using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using UserCVuploader.Data;
using UserCVuploader.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserCVuploader.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cv = _context.CVs.ToList();
            return View(cv);
        }
    }
}