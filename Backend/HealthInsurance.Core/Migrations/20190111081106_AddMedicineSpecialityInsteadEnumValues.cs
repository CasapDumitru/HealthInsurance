using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthInsurance.Core.Migrations
{
    public partial class AddMedicineSpecialityInsteadEnumValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicineType",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "MedicineSpecialityId",
                table: "Departments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MedicineSpeciality",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineSpeciality", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_MedicineSpecialityId",
                table: "Departments",
                column: "MedicineSpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_MedicineSpeciality_MedicineSpecialityId",
                table: "Departments",
                column: "MedicineSpecialityId",
                principalTable: "MedicineSpeciality",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_MedicineSpeciality_MedicineSpecialityId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "MedicineSpeciality");

            migrationBuilder.DropIndex(
                name: "IX_Departments_MedicineSpecialityId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "MedicineSpecialityId",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "MedicineType",
                table: "Departments",
                nullable: false,
                defaultValue: 0);
        }
    }
}
