using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeManagment.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class LinkIncomesToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Incomes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_ApplicationUserId",
                table: "Incomes",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_AspNetUsers_ApplicationUserId",
                table: "Incomes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_AspNetUsers_ApplicationUserId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_ApplicationUserId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Incomes");
        }
    }
}
