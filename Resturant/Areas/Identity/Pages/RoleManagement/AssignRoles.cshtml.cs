using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Resturant.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant.Areas.Identity.Pages.RoleManagement
{
    public class AssignRolesModel : PageModel
    {
        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AssignRolesModel(UserManager<Customer> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [BindProperty]
        public string SelectedUserId { get; set; }

        [BindProperty]
        public string SelectedRoleId { get; set; }

        public SelectList Users { get; set; }
        public SelectList Roles { get; set; }

        public async Task OnGetAsync()
        {
            Users = new SelectList(await _userManager.Users.ToListAsync(), "Id", "UserName");
            Roles = new SelectList(await _roleManager.Roles.ToListAsync(), "Id", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByIdAsync(SelectedUserId);
            var role = await _roleManager.FindByIdAsync(SelectedRoleId);

            if (user == null || role == null)
            {
                return NotFound();
            }

            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (result.Succeeded)
            {
                return RedirectToPage("./Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}
