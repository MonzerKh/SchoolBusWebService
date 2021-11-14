using DataAccessLayer.DataAccess;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.DataLayer.Tables.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Data
{
    public class Seed
    {
        public static async Task SeedUsers(ApplicationDbContext context)
        {
            if (await context.SystemUsers.AnyAsync()) return;

            using var hamc = new HMACSHA512();
            var item = new SystemUser()
            {
                UserName = "admin",
                Full_Name = "Monzer Alkhiami",
                PasswordHash = hamc.ComputeHash(Encoding.UTF8.GetBytes("admin")),
                PasswordSalt = hamc.Key
            };
            context.SystemUsers.Add(item);
            await context.SaveChangesAsync();

        }
    }
}
