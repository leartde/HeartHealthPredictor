using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class PredictionEntityChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeartDiseasePredictions_Patients_PatientId",
                table: "HeartDiseasePredictions");

            migrationBuilder.DropIndex(
                name: "IX_HeartDiseasePredictions_PatientId",
                table: "HeartDiseasePredictions");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "HeartDiseasePredictions",
                newName: "RecordId");

            migrationBuilder.AddColumn<int>(
                name: "ClinicalRecordId",
                table: "HeartDiseasePredictions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HeartDiseasePredictions_ClinicalRecordId",
                table: "HeartDiseasePredictions",
                column: "ClinicalRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeartDiseasePredictions_ClinicalRecords_ClinicalRecordId",
                table: "HeartDiseasePredictions",
                column: "ClinicalRecordId",
                principalTable: "ClinicalRecords",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeartDiseasePredictions_ClinicalRecords_ClinicalRecordId",
                table: "HeartDiseasePredictions");

            migrationBuilder.DropIndex(
                name: "IX_HeartDiseasePredictions_ClinicalRecordId",
                table: "HeartDiseasePredictions");

            migrationBuilder.DropColumn(
                name: "ClinicalRecordId",
                table: "HeartDiseasePredictions");

            migrationBuilder.RenameColumn(
                name: "RecordId",
                table: "HeartDiseasePredictions",
                newName: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_HeartDiseasePredictions_PatientId",
                table: "HeartDiseasePredictions",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_HeartDiseasePredictions_Patients_PatientId",
                table: "HeartDiseasePredictions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
