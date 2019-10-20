using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace H.Initializer.Pages
{
    public class NoPermissionModel : PageModel
    {
        internal static DbContext _dbContext;

        public NoPermissionModel()
        {
        }

        public void OnGet()
        {
        }
    }
}