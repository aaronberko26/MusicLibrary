using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UserNotNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<string>(
     name: "name",
     table: "user",
     nullable: false,
     oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "user",
                nullable: false,
                oldNullable: true);

            /// <inheritdoc />
        }
    }
}
