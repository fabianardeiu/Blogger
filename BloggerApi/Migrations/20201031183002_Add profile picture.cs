using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloggerApi.Migrations
{
    public partial class Addprofilepicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Persons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Persons");
        }
    }
}
