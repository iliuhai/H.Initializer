using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace H.Initializer.DbInit.Pages
{
    public class DatabaseMigrateModel : PageModel
    {
        internal static DbContext _dbContext;

        public DatabaseMigrateModel()
        {
            _dbContext = GlobalVariable.DbContext;
        }

        public IActionResult OnPostDatabaseMigrate()
        {
            if (_dbContext == null)
                throw new NullReferenceException("DbContext is null");

            if (GlobalVariable.IsMigrated)
            {
                _dbContext.Dispose();
                return new JsonResult(GlobalVariable.CallbackUrl);
            }

            try
            {
                //bool bol = _dbContext.Database.Migrate();
                //if (!bol)
                //    throw new Exception("EnsureCreated is failed!");
                GlobalVariable.IsMigrated = true;
                return new JsonResult(GlobalVariable.CallbackUrl);
            }
            finally
            {
                _dbContext.Dispose();
            }
        }
    }
}
