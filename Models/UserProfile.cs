﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace UserCVuploader.Models
{
    public class UserProfile
    {
       
            [Key]
            public string UserId { get; set; }

            [ForeignKey("UserId")]
            public IdentityUser User { get; set; }

            public string CVFilePath { get; set; }
        

    }
}
