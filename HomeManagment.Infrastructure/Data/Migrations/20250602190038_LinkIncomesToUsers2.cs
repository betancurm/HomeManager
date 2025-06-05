using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeManagment.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class LinkIncomesToUsers2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_AspNetUsers_ApplicationUserId",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Incomes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Expenses",
                newName: "ApplicationUserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "Incomes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_AspNetUsers_ApplicationUserId",
                table: "Incomes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_AspNetUsers_ApplicationUserId",
                table: "Incomes");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Expenses",
                newName: "UserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationUserId",
                table: "Incomes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Incomes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_AspNetUsers_ApplicationUserId",
                table: "Incomes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
