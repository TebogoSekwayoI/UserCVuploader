using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using UserCVuploader.Models;

namespace CVUploader.ViewModels
{
    public class AdminViewModel
    {
        public List<IdentityUser> Users { get; set; }
        public List<CV> CVs { get; set; }
    }
}