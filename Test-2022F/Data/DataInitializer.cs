using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Test_2022F.Models;
using Newtonsoft.Json.Linq;

namespace Test_2022F.Data
{
    public class DataInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // TestNote: Create an "Admin" Role

            // TestNote: Create a test user, set their Country to Canada, date of birth to Jan 01 2000, user name and email to test@test.com and password to testing1234

            // TestNote: add the test user to the "Admin" role.

            // TestNote: Create two Books, One Book’s Edition must be 1, the other must be greater than 1, and add them to the database

            ApplicationUser user1 = new ApplicationUser
            {
                Country = "Canada",
                DateOfBirth = new DateTime(2000, 1, 1),
                UserName = "test@test.com",
                Email = "test@test.com"
            };
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            IdentityRole role1 = new IdentityRole { Name = "Admin" };
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);

            roleManager.Create(role1);
            userManager.Create(user1, "testing1234");
            userManager.AddToRole(user1.Id, "Admin");

            Book B1 = new Book
            {
                Id = 1,
                Title = "The NEw Spring",               
                Published = new DateTime(1965,10,10),
                Edition = 1,
                ISBN = "123456789",
                Owner= user1
            };

            Book B2 = new Book
            {
                Id = 1,
                Title = "The NEw Winter",
                Published = new DateTime(1970, 10, 10),
                Edition = 6,                
                Owner = user1
            };
            context.Books.Add(B1);
            user1.Books.Add(B1);
            context.Books.Add(B2);
            user1.Books.Add(B2);

            base.Seed(context);
        }
    }
}