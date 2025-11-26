using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MyApp.Data.Enums;

#nullable disable

namespace WebApi.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Fullname = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            var password = "SuperPassword!@#";
            var hash = BCrypt.Net.BCrypt.HashPassword(password);
            
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Username", "Fullname", "PasswordHash", "Role" },
                values: new object[]
                {
                    Guid.NewGuid(),       
                    "admin",             
                    "Administrator",      
                    hash, 
                    0
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
