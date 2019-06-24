using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMA.Db.Migrations
{
    public partial class ContactModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Contacts",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Contacts",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoId",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Photos_PhotoId",
                table: "Contacts",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PhotoId",
                table: "Contacts",
                column: "PhotoId");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Photos_PhotoId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_PhotoId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Contacts",
                nullable: true);
        }
    }
}
