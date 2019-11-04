using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace H.Initializer.DbInit.Pages
{
    public class DatabaseUpdateModel : PageModel
    {
        internal static DbContext _dbContext;

        public DatabaseUpdateModel()
        {
            _dbContext = GlobalVariable.DbContext;
        }

        public IActionResult OnPostDatabaseUpdate()
        {
            if (_dbContext == null)
                throw new NullReferenceException("DbContext is null");

            if (GlobalVariable.IsUpdated)
            {
                _dbContext.Dispose();
                return new JsonResult(GlobalVariable.CallbackUrl);
            }

            try
            {
                //bool bol = _dbContext.Database.Migrate();
                //if (!bol)
                //    throw new Exception("EnsureCreated is failed!");
                GlobalVariable.IsUpdated = true;
                return new JsonResult(GlobalVariable.CallbackUrl);
            }
            finally
            {
                _dbContext.Dispose();
            }
        }
    }
}
