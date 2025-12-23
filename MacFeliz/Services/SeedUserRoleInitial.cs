using Microsoft.AspNetCore.Identity;

namespace MacFeliz.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {

        private readonly UserManager<IdentityUser> _userManeger;
        private readonly RoleManager<IdentityRole> _roleManeger;

        public SeedUserRoleInitial(UserManager<IdentityUser> userManeger, RoleManager<IdentityRole> roleManeger)
        {
            _userManeger = userManeger;
            _roleManeger = roleManeger;
        }

        public void SeedRoles()
        {
            if (!_roleManeger.RoleExistsAsync("Member").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Member";
                role.NormalizedName = "MEMBER";
                IdentityResult roleResult = _roleManeger.CreateAsync(role).Result;
            }

            if (!_roleManeger.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManeger.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
            if (_userManeger.FindByEmailAsync("usuario@localhost").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "usuario@localhost";
                user.Email = "usuario@localhost";
                user.NormalizedUserName = "USUARIO@LOCALHOST";
                user.NormalizedEmail = "USUARIO@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManeger.CreateAsync(user, "Numsey#2022").Result;

                if (result.Succeeded)
                {
                    _userManeger.AddToRoleAsync(user, "Member").Wait();
                }
            }

            if (_userManeger.FindByEmailAsync("admin@localhost").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin@localhost";
                user.Email = "admin@localhost";
                user.NormalizedUserName = "ADMIN@LOCALHOST";
                user.NormalizedEmail = "ADMIN@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManeger.CreateAsync(user, "Numsey#2022").Result;

                if (result.Succeeded)
                {
                    _userManeger.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}