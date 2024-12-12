using HummanResourceManagementSystem.Context;
using HummanResourceManagementSystem.DTOs.Authantication.Request;
using HummanResourceManagementSystem.Helper;
using HummanResourceManagementSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace HummanResourceManagementSystem.Implementation
{
    public class AuthanticationService : IAuthanticationService
    {
        private readonly HRMSDbContext _context;
        public AuthanticationService(HRMSDbContext context)
        {
            _context = context;
        }

        public async Task<string> Login(LoginDTO input)
        {
            if (input != null)
            {
                if(!string.IsNullOrEmpty(input.Email) && !string.IsNullOrEmpty(input.Password))
                {
                    input.Email = EncryptionHelper.GenerateSHA384String(input.Email);
                    input.Password = EncryptionHelper.GenerateSHA384String(input.Password);
                    var authUser= await (from p in _context.Persons 
                                         join li in _context.LookupItems
                                         on p.UserTypeId equals li.Id
                                  where p.Email == input.Email && p.Password == input.Password
                                  select new
                                  {
                                      PersonId = p.Id.ToString(),
                                      Role = li.Name.ToString(),
                                  }).FirstOrDefaultAsync();
                    return authUser != null ? await TokenHelper.GenerateToken(authUser.PersonId,authUser.Role) : "Authantication Failed";
                    //if ()
                    //    return ;
                    //else return false;
                }
                else
                {
                    throw new Exception("Email and Password Are Required");
                }
            }
            else
            {

                throw new Exception("Email and Password Are Required");

            }
        }

        
    }
}
