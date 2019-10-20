using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace H.Initializer.DbInit.Pages
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

        public IActionResult OnPostDatabaseCreate()
        {
            if (_dbContext == null)
                throw new NullReferenceException("DbContext is null");

            if (GlobalVariable.CanConnect)
            {
                _dbContext.Dispose();
                return new JsonResult(GlobalVariable.CallbackUrl);
            }

            try
            {
                bool bol = _dbContext.Database.EnsureCreated();
                if (!bol)
                    throw new Exception("EnsureCreated is failed!");
                GlobalVariable.CanConnect = true;
                return new JsonResult(GlobalVariable.CallbackUrl);
            }
            catch
            {
                return new JsonResult("../DatabaseConnectException");
            }
            finally
            {
                _dbContext.Dispose();
            }
        }
    }
}