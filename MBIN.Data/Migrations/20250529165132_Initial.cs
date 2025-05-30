﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MBIN.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Email", "Gender", "LastUpdateDate", "Mobile", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "MobinEffati@gmail.com", true, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "09906888135", "12481632", "MobinEfati" },
                    { 2, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ElhamAzizzade@gmail.com", false, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "09197701747", "12481632", "ElhamAzizzade" }
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
