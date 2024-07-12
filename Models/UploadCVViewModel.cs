using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace UserCVuploader.Models
{
    public class UploadCVViewModel
    {
        [Required]
        public IFormFile CV { get; set; }
    }
}
