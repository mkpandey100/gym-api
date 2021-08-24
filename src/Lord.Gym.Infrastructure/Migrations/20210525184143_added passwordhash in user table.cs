using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lord.Gym.Infrastructure.Migrations
{
    public partial class addedpasswordhashinusertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "AspNetUsers");
        }
    }
}
