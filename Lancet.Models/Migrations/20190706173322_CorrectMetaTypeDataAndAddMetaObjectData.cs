using Lancet.Data;
using Lancet.Models.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Lancet.Models.Migrations
{
    public partial class CorrectMetaTypeDataAndAddMetaObjectData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LancetContext>();
            var options = optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=lancet_db;Username=postgres;Password=340571578;Integrated Security=false;").Options;


            using (LancetContext context = new LancetContext(options))
            {
                var metaType = context.MetaTypes.Find(Types.User.Id);
                context.MetaTypes.Remove(metaType);
                metaType = context.MetaTypes.Find(Types.Admin.Id);
                context.MetaTypes.Remove(metaType);

                var metaObject = new MetaObject() {
                    Id = Objects.Admin.Id,
                    Title = "Admin",
                    Name = "admin",
                    MetaTypeId = Types.Role.Id,
                    CreateDate = DateTime.Now.ToUniversalTime()
                };
                context.MetaObjects.Add(metaObject);

                metaObject = new MetaObject()
                {
                    Id = Objects.User.Id,
                    Title = "User",
                    Name = "user",
                    MetaTypeId = Types.Role.Id,
                    CreateDate = DateTime.Now.ToUniversalTime()
                };
                context.MetaObjects.Add(metaObject);

                context.SaveChanges();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
