﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityApp.Data;
using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Pages.Invoices
{
    [AllowAnonymous]
    public class IndexModel : DI_BasePageModel
    {
        public IndexModel(ApplicationDbContext applicationDbContext, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager) : base(applicationDbContext, authorizationService, userManager)
        {
        }

        public IList<Invoice> Invoice { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var currentUserId = UserManager.GetUserId(User);
            
            Invoice = await Context.Invoice
                .Where(u => u.CreatorId == currentUserId)
                .ToListAsync();
        }
    }
}
