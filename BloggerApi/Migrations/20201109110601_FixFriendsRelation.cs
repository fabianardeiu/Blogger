﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloggerApi.Migrations
{
    public partial class FixFriendsRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FriendId",
                table: "Friends",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FriendId",
                table: "Friends");
        }
    }
}
