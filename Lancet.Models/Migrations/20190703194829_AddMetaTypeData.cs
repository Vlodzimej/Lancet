using Lancet.Data;
using Lancet.Models.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using System;

namespace Lancet.Models.Migrations
{
    public partial class AddMetaTypeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LancetContext>();
            var options = optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=lancet_db;Username=postgres;Password=340571578;Integrated Security=false;").Options;


            using (LancetContext context = new LancetContext(options))
            {
                /// Тип Объект - Аккаунт
                context.MetaTypes.Add(new MetaType()
                {
                    Id = Types.Account.Id,
                    Title = "account",
                    Name = "Account"
                });

                /// Тип Объект - Группа
                context.MetaTypes.Add(new MetaType()
                {
                    Id = Types.Group.Id,
                    Title = "group",
                    Name = "Group"
                });

                /// Тип Объект - Страница
                context.MetaTypes.Add(new MetaType()
                {
                    Id = Types.Page.Id,
                    Title = "page",
                    Name = "Page"
                });

                /// Тип Связь - Роль
                context.MetaTypes.Add(new MetaType()
                {
                    Id = Types.Role.Id,
                    Title = "role",
                    Name = "Role"
                });

                /// Тип Роль - Админ
                context.MetaTypes.Add(new MetaType()
                {
                    Id = Types.Admin.Id,
                    Title = "admin",
                    Name = "Admin"
                });

                /// Тип Роль - Юзер
                context.MetaTypes.Add(new MetaType()
                {
                    Id = Types.User.Id,
                    Title = "user",
                    Name = "User"
                });

                context.SaveChanges();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}