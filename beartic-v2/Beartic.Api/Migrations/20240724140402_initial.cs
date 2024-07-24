using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Beartic.Api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    username = table.Column<string>(type: "varchar(50)", nullable: false),
                    name_firstname = table.Column<string>(type: "varchar(50)", nullable: false),
                    name_lastname = table.Column<string>(type: "varchar(50)", nullable: false),
                    email_address = table.Column<string>(type: "varchar(100)", nullable: false),
                    document_number = table.Column<string>(type: "varchar(14)", nullable: false),
                    document_type = table.Column<int>(type: "int", nullable: false),
                    phone_number = table.Column<string>(type: "varchar(11)", fixedLength: true, nullable: false),
                    password_hash = table.Column<string>(type: "varchar(100)", nullable: false),
                    password_key = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
