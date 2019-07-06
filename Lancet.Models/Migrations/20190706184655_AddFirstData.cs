using Lancet.Data;
using Lancet.Models.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Lancet.Models.Migrations
{
    public partial class AddFirstData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LancetContext>();
            var options = optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=lancet_db;Username=postgres;Password=340571578;Integrated Security=false;").Options;
            var createDate = DateTime.Now.ToUniversalTime();

            using (LancetContext context = new LancetContext(options))
            {
                //Тестовая страница
                var metaObject = new MetaObject()
                {
                    Id = Guid.NewGuid(),
                    Title = "Test Page",
                    Name = "testpage",
                    MetaTypeId = Types.Page.Id,
                    CreateDate = createDate,
                    Content = "<h1>Test header</h1>"
                };
                context.MetaObjects.Add(metaObject);

                //Связь страницы с ролью
                var relation = new Relation()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = createDate
                };
                context.Relations.Add(relation);

                var objectRelation = new ObjectRelation()
                {
                    Id = Guid.NewGuid(),
                    MetaTypeId = Types.Role.Id,
                    RelationId = relation.Id,
                    MetaObjectId = metaObject.Id
                };
                context.ObjectRelations.Add(objectRelation);

                objectRelation = new ObjectRelation()
                {
                    Id = Guid.NewGuid(),
                    MetaTypeId = Types.Role.Id,
                    RelationId = relation.Id,
                    MetaObjectId = Objects.User.Id
                };
                context.ObjectRelations.Add(objectRelation);

                //Связь аккаунта с ролью
                relation = new Relation()
                {
                    Id = Guid.NewGuid(),
                    CreateDate = createDate
                };
                context.Relations.Add(relation);

                var account = context.MetaObjects.Find(Guid.Parse("b0e56288-e7be-4ceb-a64a-c5a6f1023738"));

                objectRelation = new ObjectRelation()
                {
                    Id = Guid.NewGuid(),
                    MetaTypeId = Types.Role.Id,
                    RelationId = relation.Id,
                    MetaObjectId = account.Id
                };
                context.ObjectRelations.Add(objectRelation);

                objectRelation = new ObjectRelation()
                {
                    Id = Guid.NewGuid(),
                    MetaTypeId = Types.Role.Id,
                    RelationId = relation.Id,
                    MetaObjectId = Objects.User.Id
                };
                context.ObjectRelations.Add(objectRelation);

                context.SaveChanges();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
