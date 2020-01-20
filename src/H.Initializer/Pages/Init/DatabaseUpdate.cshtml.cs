using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace H.Initializer.Init.Pages
{
    public class DatabaseUpdateModel : PageModel
    {
        internal static DbContext _dbContext;

        public DatabaseUpdateModel()
        {
            _dbContext = GlobalVariable.DbContext;
        }

        public IActionResult OnPostMigrate()
        {
            if (_dbContext == null)
                throw new NullReferenceException("DbContext is null");

            if (GlobalVariable.IsUpdated)
            {
                _dbContext.Dispose();
                return new JsonResult(new { success = true, message = "", data = GlobalVariable.CallbackUrl });
            }

            try
            {
                //bool bol = _dbContext.Database.Migrate();
                //if (!bol)
                //    throw new Exception("EnsureCreated is failed!");
                GlobalVariable.IsUpdated = true;
                return new JsonResult(new { success = true, message = "", data = GlobalVariable.CallbackUrl });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = true, message = "", data = ex.Message });
            }
        }
    }
}
