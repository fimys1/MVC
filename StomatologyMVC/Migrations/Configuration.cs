namespace StomatologyMVC.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StomatologyMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // ������� ��� ����
            var role1 = new IdentityRole { Name = "Admin" };
            var role2 = new IdentityRole { Name = "User" };
            // ��������� ���� � ��
            roleManager.Create(role1);
            roleManager.Create(role2);

            // ������� �������������
            var admin = new ApplicationUser { Email = "admin@mail.ru", UserName = "admin@mail.ru" };
            string password = ",Jlb,bklbyu12345a";
            var result = userManager.Create(admin, password);

            // ���� �������� ������������ ������ �������
            if (result.Succeeded)
            {
                // ��������� ��� ������������ ����
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
