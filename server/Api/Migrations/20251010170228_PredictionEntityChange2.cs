using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class PredictionEntityChange2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeartDiseasePredictions_ClinicalRecords_ClinicalRecordId",
                table: "HeartDiseasePredictions");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "HeartDiseasePredictions");

            migrationBuilder.AlterColumn<int>(
                name: "ClinicalRecordId",
                table: "HeartDiseasePredictions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HeartDiseasePredictions_ClinicalRecords_ClinicalRecordId",
                table: "HeartDiseasePredictions",
                column: "ClinicalRecordId",
                principalTable: "ClinicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeartDiseasePredictions_ClinicalRecords_ClinicalRecordId",
                table: "HeartDiseasePredictions");

            migrationBuilder.AlterColumn<int>(
                name: "ClinicalRecordId",
                table: "HeartDiseasePredictions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RecordId",
                table: "HeartDiseasePredictions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_HeartDiseasePredictions_ClinicalRecords_ClinicalRecordId",
                table: "HeartDiseasePredictions",
                column: "ClinicalRecordId",
                principalTable: "ClinicalRecords",
                principalColumn: "Id");
        }
    }
}
