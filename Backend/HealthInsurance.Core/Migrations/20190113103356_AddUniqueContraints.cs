using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthInsurance.Core.Migrations
{
    public partial class AddUniqueContraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserReviews",
                table: "UserReviews");

            migrationBuilder.DropIndex(
                name: "IX_UserReviews_AuthorId",
                table: "UserReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfficeReviews",
                table: "OfficeReviews");

            migrationBuilder.DropIndex(
                name: "IX_OfficeReviews_AuthorId",
                table: "OfficeReviews");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserReviews");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OfficeReviews");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "UserReviews",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "OfficeReviews",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserReviews",
                table: "UserReviews",
                columns: new[] { "AuthorId", "RecipientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfficeReviews",
                table: "OfficeReviews",
                columns: new[] { "AuthorId", "RecipientId" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offices_Name",
                table: "Offices",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineSpeciality_Name",
                table: "MedicineSpeciality",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserReviews",
                table: "UserReviews");

            migrationBuilder.DropIndex(
                name: "IX_Offices_Name",
                table: "Offices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfficeReviews",
                table: "OfficeReviews");

            migrationBuilder.DropIndex(
                name: "IX_MedicineSpeciality_Name",
                table: "MedicineSpeciality");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "UserReviews",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserReviews",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "OfficeReviews",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OfficeReviews",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserReviews",
                table: "UserReviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfficeReviews",
                table: "OfficeReviews",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_AuthorId",
                table: "UserReviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeReviews_AuthorId",
                table: "OfficeReviews",
                column: "AuthorId");
        }
    }
}
