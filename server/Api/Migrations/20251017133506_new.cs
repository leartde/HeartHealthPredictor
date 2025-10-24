using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeartDiseasePredictions");

            migrationBuilder.AddColumn<bool>(
                name: "Label",
                table: "ClinicalRecords",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Probability",
                table: "ClinicalRecords",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "ClinicalRecords");

            migrationBuilder.DropColumn(
                name: "Probability",
                table: "ClinicalRecords");

            migrationBuilder.CreateTable(
                name: "HeartDiseasePredictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicalRecordId = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<bool>(type: "bit", nullable: false),
                    Probability = table.Column<double>(type: "float", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeartDiseasePredictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeartDiseasePredictions_ClinicalRecords_ClinicalRecordId",
                        column: x => x.ClinicalRecordId,
                        principalTable: "ClinicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeartDiseasePredictions_ClinicalRecordId",
                table: "HeartDiseasePredictions",
                column: "ClinicalRecordId");
        }
    }
}
