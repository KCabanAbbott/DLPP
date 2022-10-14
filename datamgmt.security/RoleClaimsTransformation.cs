using datamgmt.domain.DbContexts;
using datamgmt.domain.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace datamgmt.security
{
    public class RoleClaimsTransformation : IClaimsTransformation
    {
        private readonly IServiceProvider _serviceProvider;

        public RoleClaimsTransformation(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {

            var clone = principal.Clone();
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            var newIdentity = (ClaimsIdentity)clone.Identity;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.

            string loginName = newIdentity.Name.Substring(1 + newIdentity.Name.IndexOf("\\"));

            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DataMgmtDbContext>();

                UserAccountRepository userAccountRepository = new UserAccountRepository(dbContext);

                newIdentity.AddClaim(new Claim(newIdentity.RoleClaimType, "Admin"));

                /*List<UserAccountRole> userAccountRoles = (List<UserAccountRole>)userAccountRepository.GetUserRoles(loginName);

                //List<UserAccountRole> userAccountRoles = new List<UserAccountRole>();

                foreach (UserAccountRole userAccountRole in userAccountRoles)
                {
                    if (userAccountRole.UserRoleID == 1)
                    {
                        newIdentity.AddClaim(new Claim(newIdentity.RoleClaimType, "User"));
                    }
                    else if (userAccountRole.UserRoleID == 2)
                    {
                        newIdentity.AddClaim(new Claim(newIdentity.RoleClaimType, "Admin"));
                    }
                    else if (userAccountRole.UserRoleID == 3)
                    {
                        newIdentity.AddClaim(new Claim(newIdentity.RoleClaimType, "Super Admin"));
                    }
                }*/


            }
            return await Task.FromResult(principal);
        }
    }
}
