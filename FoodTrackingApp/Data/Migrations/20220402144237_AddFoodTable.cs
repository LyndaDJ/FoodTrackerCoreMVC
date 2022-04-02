﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTrackingApp.Data.Migrations
{
    public partial class AddFoodTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Meal = table.Column<int>(type: "int", nullable: false),
                    Carbohydrate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Protein = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Snacks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRecord", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodRecord");
        }
    }
}
