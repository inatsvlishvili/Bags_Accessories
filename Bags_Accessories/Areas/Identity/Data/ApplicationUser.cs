﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bags_Accessories.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{    
    [Column(TypeName ="nvarchar(100)")]
    public string FirstName { get; internal set; }
        
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; internal set; }
}

