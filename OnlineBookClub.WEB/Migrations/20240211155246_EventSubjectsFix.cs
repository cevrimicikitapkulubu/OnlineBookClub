using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBookClub.WEB.Migrations
{
    public partial class EventSubjectsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MODIFIED_USER_ID",
                table: "EventSubjects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "MODIFIED_DATE",
                table: "EventSubjects",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<string>(
                name: "CREATED_USER_ID",
                table: "EventSubjects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MODIFIED_USER_ID",
                table: "EventSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "MODIFIED_DATE",
                table: "EventSubjects",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CREATED_USER_ID",
                table: "EventSubjects",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
