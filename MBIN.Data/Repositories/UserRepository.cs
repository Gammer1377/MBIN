using MBIN.Data.Context;
using MBIN.Data.Contracts;
using MBIN.Entity.DTOs;
using MBIN.Entity.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MBIN.Data.Repositories
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> EmailExist(string email)
        {
            var Query = _context.Users.AnyAsync(u => u.Email.Trim() == email.Trim());

            return Query.Result;
        }

        public User Login(string email, string password)
        {
            var Query = _context.Users.SingleOrDefault(u => u.Email == email.Trim() && u.Password == password);

            if (Query == null)
            {
                return null;
            }
            else
            {
                var key = Encoding.ASCII.GetBytes("Jwt Token");

                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescription = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,Query.UserName),
                        new Claim(ClaimTypes.Email,Query.Email),
                        new Claim(ClaimTypes.Gender,Query.Gender.ToString()),
                        new Claim("Id",Query.Id.ToString()),
                        new Claim(ClaimTypes.MobilePhone,Query.Mobile)
                    }),
                    Expires = DateTime.Now.AddDays(10),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                        ),
                    Issuer = "MBIN",
                    Audience = "MBIN.Com"
                };

                var token = tokenHandler.CreateToken(tokenDescription);

                Query.JWTSecret = tokenHandler.WriteToken(token);

                return Query;
            }
        }

    }
}
