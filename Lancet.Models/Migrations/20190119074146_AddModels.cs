using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lancet.Models.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetaDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    MetaTypeId = table.Column<Guid>(nullable: false),
                    MetaObjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetaObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    MetaTypeId = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    FinishDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetaTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MetaObjectId = table.Column<Guid>(nullable: false),
                    RelationId = table.Column<Guid>(nullable: false),
                    MetaTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectRelations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetaDatas");

            migrationBuilder.DropTable(
                name: "MetaObjects");

            migrationBuilder.DropTable(
                name: "MetaTypes");

            migrationBuilder.DropTable(
                name: "ObjectRelations");

            migrationBuilder.DropTable(
                name: "Relations");
        }
    }
}
