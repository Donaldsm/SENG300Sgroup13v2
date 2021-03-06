﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SENG300Scholarships.Migrations
{
    // This code was made to build the database system on SQlite, these migrations have already been run and they are a one time use.
    // This Migration was used to do the initial create of the database building out each table in the dd.db file found in the project.
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nomination",
                columns: table => new
                {
                    NominationID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScholarshipID = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Letter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nomination", x => x.NominationID);
                });

            migrationBuilder.CreateTable(
                name: "Scholarship",
                columns: table => new
                {
                    ScholarshipID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    value = table.Column<int>(nullable: false),
                    amount = table.Column<int>(nullable: false),
                    org = table.Column<string>(nullable: true),
                    duration = table.Column<string>(nullable: true),
                    deadline = table.Column<DateTime>(nullable: false),
                    scope = table.Column<string>(nullable: true),
                    major = table.Column<string>(nullable: true),
                    GPA = table.Column<float>(nullable: false),
                    UploadPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scholarship", x => x.ScholarshipID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Submission",
                columns: table => new
                {
                    SubmissionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Student = table.Column<string>(nullable: true),
                    StudentID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    School = table.Column<string>(nullable: true),
                    GPA = table.Column<double>(nullable: false),
                    Year = table.Column<double>(nullable: false),
                    ScholarshipID = table.Column<int>(nullable: false),
                    ReferenceName = table.Column<string>(nullable: true),
                    ReferenceEmail = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    File = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submission", x => x.SubmissionId);
                    table.ForeignKey(
                        name: "FK_Submission_Scholarship_ScholarshipID",
                        column: x => x.ScholarshipID,
                        principalTable: "Scholarship",
                        principalColumn: "ScholarshipID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Submission_ScholarshipID",
                table: "Submission",
                column: "ScholarshipID");
        }
        // this code is used to drop the tables from the database though it is never called.
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nomination");

            migrationBuilder.DropTable(
                name: "Submission");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Scholarship");
        }
    }
}
