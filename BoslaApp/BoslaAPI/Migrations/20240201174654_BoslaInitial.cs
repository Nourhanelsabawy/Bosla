using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoslaAPI.Migrations
{
    /// <inheritdoc />
    public partial class BoslaInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false),
                    Age = table.Column<int>(type: "INT", nullable: false),
                    Gender = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    ProfileImage = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    RelativeName = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false),
                    RelativePhone = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Specialization = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false),
                    Age = table.Column<int>(type: "INT", nullable: false),
                    Gender = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    ProfileImage = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: true),
                    RelativeName = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false),
                    RelativePhone = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    BloodType = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Disease = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    AllergicFoods = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_DrId",
                        column: x => x.DrId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatId = table.Column<int>(type: "int", nullable: false),
                    Diagnose = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Prescription = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistories_Patients_PatId",
                        column: x => x.PatId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "Address", "Age", "Gender", "Name", "ProfileImage", "RelativeName", "RelativePhone" },
                values: new object[,]
                {
                    { 1, "123 Playground Lane", 8, "Female", "Emily Doe", "child_profile1.jpg", "John Doe", "555-5678" },
                    { 2, "456 Toy Street", 5, "Male", "Jacob Smith", "child_profile2.jpg", "Jane Smith", "555-4321" },
                    { 3, "789 Fun Avenue", 7, "Female", "Olivia Johnson", "child_profile3.jpg", "Bob Johnson", "555-2222" },
                    { 4, "987 Playful Road", 6, "Male", "Liam Turner", "child_profile4.jpg", "Lisa Turner", "555-4444" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Name", "Phone", "Specialization" },
                values: new object[,]
                {
                    { 1, "Dr. John Doe", "123-456-7890", "diabetes" },
                    { 2, "Dr. Jane Smith", "987-654-3210", "heart diseases" },
                    { 3, "Dr. Alice Johnson", "555-123-4567", "alzheimer" },
                    { 4, "Dr. Rebert Soll", "555-852-4567", "autism" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "Age", "AllergicFoods", "BloodType", "Disease", "DrId", "Gender", "Name", "Phone", "ProfileImage", "RelativeName", "RelativePhone" },
                values: new object[,]
                {
                    { 1, "123 Main Street", 30, "Peanuts, Shellfish", "O+", "Diabetes", 1, "Male", "John Doe", "555-1234", "profile1.jpg", "Jane Doe", "555-5678" },
                    { 2, "456 Oak Avenue", 45, "Dairy, Gluten", "A-", "Heart Disease", 2, "Female", "Jane Smith", "555-9876", "profile2.jpg", "John Smith", "555-4321" },
                    { 3, "789 Pine Lane", 28, "Tree Nuts, Soy", "AB+", "Alzheimer", 3, "Female", "Alice Johnson", "555-1111", "profile3.jpg", "Bob Johnson", "555-2222" },
                    { 4, "987 Cedar Street", 35, "Eggs, Fish", "B-", "Autism", 4, "Male", "Mason Turner", "555-3333", "profile4.jpg", "Lisa Turner", "555-4444" },
                    { 5, "654 Birch Avenue", 22, "Milk, Wheat", "O-", "Diabetes", 1, "Female", "Sophia White", "555-5555", "profile5.jpg", "David White", "555-6666" },
                    { 6, "321 Elm Road", 40, "Shellfish, Peanuts", "A+", "Heart Disease", 2, "Male", "Elijah Brown", "555-7777", "profile6.jpg", "Sarah Brown", "555-8888" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_PatId",
                table: "MedicalHistories",
                column: "PatId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DrId",
                table: "Patients",
                column: "DrId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "MedicalHistories");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
