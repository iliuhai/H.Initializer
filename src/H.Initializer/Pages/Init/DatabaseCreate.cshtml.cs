using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace H.Initializer.Init.Pages
{
    public class DatabaseCreateModel : PageModel
    {
        internal static DbContext _dbContext;

        public DatabaseCreateModel()
        {
            _dbContext = GlobalVariable.DbContext;
        }

        public IActionResult OnGet()
        {
            if (GlobalVariable.CanConnect)
                return Redirect(GlobalVariable.CallbackUrl);
            return Page();
        }

        public IActionResult OnPostEnsure()
        {
            if (_dbContext == null)
                return new JsonResult(new { success = true, message = "", data = "DbContext is null" });

            if (GlobalVariable.CanConnect)
            {
                _dbContext.Dispose();
                return new JsonResult(new { success = true, message = "", data = GlobalVariable.CallbackUrl });
            }

            try
            {
                bool bol = _dbContext.Database.EnsureCreated();
                if (!bol)
                    throw new Exception("EnsureCreated is failed!");
                GlobalVariable.CanConnect = true;
                return new JsonResult(new { success = true, message = "", data = GlobalVariable.CallbackUrl });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = true, message = "", data = ex.Message });
            }
        }
    }
}