using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Gharshare.DataAccessLayer.Data.Infrastructure.Repository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gharshare.DataAccessLayer;
using Gharshare.CommonHelper;

namespace Gharshare.DataAccessLayer.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDBContext _dbContext;
        private readonly UnitOfWork _unitOfWork;
        public DbInitializer(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDBContext dbContext)
        //UnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
            //_unitOfWork = unitOfWork;
        }

        public async void Initialize()
        {
            try
            {
                if (_dbContext.Database.GetPendingMigrations().Count() > 0)
                {
                    _dbContext.Database.Migrate();
                }
                if (!_roleManager.RoleExistsAsync(WebSiteRoles.Role_Admin).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Role_Landlord)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Role_Tenant)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Role_Admin)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Role_SuperAdmin)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Role_FreeUser)).GetAwaiter().GetResult();
                    
                }
                IQueryable<ApplicationUser> _users = _userManager.Users.Where(x => x.UserType == ApplicationUser.usertype.superadmin);
                
                if (_users.Count() == 0)
                {
                    _userManager.CreateAsync(new ApplicationUser
                    {
                        UserName = "admin",
                        Name = "SPM admin",
                        Email = "info@smartpropertymanager.pk",
                        PhoneNumber = "+61 047 0627866",
                        Address = "724 Waverley Rd Malvern East Melbourne,Victoria, Australia",                        
                        UserType = ApplicationUser.usertype.superadmin,
                        EmailConfirmed=true,
                        DefaultAdmin=true,
                    }, "Hum@12345").GetAwaiter().GetResult();
                    ApplicationUser user = _dbContext.ApplicationUsers.FirstOrDefault(x => x.Email == "info@smartpropertymanager.pk");
                    if (user != null)
                    {
                        _userManager.AddToRoleAsync(user, WebSiteRoles.Role_Landlord).GetAwaiter().GetResult();
                        _userManager.AddToRoleAsync(user, WebSiteRoles.Role_Tenant).GetAwaiter().GetResult();
                        _userManager.AddToRoleAsync(user, WebSiteRoles.Role_Admin).GetAwaiter().GetResult();
                        _userManager.AddToRoleAsync(user, WebSiteRoles.Role_SuperAdmin).GetAwaiter().GetResult();
                        _userManager.AddToRoleAsync(user, WebSiteRoles.Role_FreeUser).GetAwaiter().GetResult();
                        _dbContext.SaveChanges();
                    }
                }
                return;
                            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
