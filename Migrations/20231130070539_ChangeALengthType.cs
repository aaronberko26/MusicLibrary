using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ChangeALengthType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "album_artist_id_fkey",
                table: "album");

            migrationBuilder.DropForeignKey(
                name: "song_artist_id_fkey",
                table: "song");

            migrationBuilder.DropIndex(
                name: "IX_song_artist_id",
                table: "song");

            migrationBuilder.DropIndex(
                name: "IX_album_artist_id",
                table: "album");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "user",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "user",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "year",
                table: "album",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "numofsongs",
                table: "album",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "label",
                table: "album",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "artist_id",
                table: "album",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "a_length",
                table: "album",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "a_genre",
                table: "album",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_album",
                table: "album",
                columns: new[] { "artist_id", "a_name" });

            migrationBuilder.CreateIndex(
                name: "unique_artist_name",
                table: "artist",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_a_name",
                table: "album",
                column: "a_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "unique_artist_name",
                table: "artist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_album",
                table: "album");

            migrationBuilder.DropIndex(
                name: "unique_a_name",
                table: "album");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "user",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "user",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "year",
                table: "album",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "numofsongs",
                table: "album",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "label",
                table: "album",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "a_length",
                table: "album",
                type: "character varying(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "a_genre",
                table: "album",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<int>(
                name: "artist_id",
                table: "album",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_song_artist_id",
                table: "song",
                column: "artist_id");

            migrationBuilder.CreateIndex(
                name: "IX_album_artist_id",
                table: "album",
                column: "artist_id");

            migrationBuilder.AddForeignKey(
                name: "album_artist_id_fkey",
                table: "album",
                column: "artist_id",
                principalTable: "artist",
                principalColumn: "artist_id");

            migrationBuilder.AddForeignKey(
                name: "song_artist_id_fkey",
                table: "song",
                column: "artist_id",
                principalTable: "artist",
                principalColumn: "artist_id");
        }
    }
}
