using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basket.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Stores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Stores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Stores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedById",
                table: "Stores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Stores",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "MainCatogries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "MainCatogries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MainCatogries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedById",
                table: "MainCatogries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "MainCatogries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_CreatedById",
                table: "Stores",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_LastUpdatedById",
                table: "Stores",
                column: "LastUpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MainCatogries_CreatedById",
                table: "MainCatogries",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MainCatogries_LastUpdatedById",
                table: "MainCatogries",
                column: "LastUpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_MainCatogries_AspNetUsers_CreatedById",
                table: "MainCatogries",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainCatogries_AspNetUsers_LastUpdatedById",
                table: "MainCatogries",
                column: "LastUpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_AspNetUsers_CreatedById",
                table: "Stores",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_AspNetUsers_LastUpdatedById",
                table: "Stores",
                column: "LastUpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainCatogries_AspNetUsers_CreatedById",
                table: "MainCatogries");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCatogries_AspNetUsers_LastUpdatedById",
                table: "MainCatogries");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_AspNetUsers_CreatedById",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_AspNetUsers_LastUpdatedById",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_CreatedById",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_LastUpdatedById",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_MainCatogries_CreatedById",
                table: "MainCatogries");

            migrationBuilder.DropIndex(
                name: "IX_MainCatogries_LastUpdatedById",
                table: "MainCatogries");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MainCatogries");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "MainCatogries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MainCatogries");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                table: "MainCatogries");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn",
                table: "MainCatogries");
        }
    }
}
