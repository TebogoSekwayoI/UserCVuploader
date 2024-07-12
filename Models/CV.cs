using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserCVuploader.Models
{
  
        public class CV
        {
            public int Id { get; set; }
            public string UserId { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Skills { get; set; }
            public string Experience { get; set; }
            public string Education { get; set; }
        }

    }

