using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBookClub.WEB.Migrations
{
    public partial class BugFix_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventRatings",
                table: "EventRatings");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "EventRatings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EventRatings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventRatings",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "SchoolNo",
                table: "AspNetUsers",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Achievements",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            //migrationBuilder.AddColumn<string>(
            //    name: "Image",
            //    table: "Achievements",
            //    type: "nvarchar(78)",
            //    maxLength: 78,
            //    nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventRatings",
                table: "EventRatings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EventRatings_EventId",
                table: "EventRatings",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventRatings",
                table: "EventRatings");

            migrationBuilder.DropIndex(
                name: "IX_EventRatings_EventId",
                table: "EventRatings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventRatings");

            //migrationBuilder.DropColumn(
            //    name: "Image",
            //    table: "Achievements");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "EventRatings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "EventRatings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolNo",
                table: "AspNetUsers",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Achievements",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventRatings",
                table: "EventRatings",
                columns: new[] { "EventId", "UserId" });
        }
    }
}
