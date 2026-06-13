using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanTeeth.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_AuditColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Patients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "Patients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Dentists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Dentists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Dentists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "Dentists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DentalOffices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "DentalOffices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "DentalOffices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "DentalOffices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Appointments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedTime",
                table: "Appointments",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Dentists");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Dentists");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Dentists");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "Dentists");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DentalOffices");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "DentalOffices");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "DentalOffices");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "DentalOffices");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "LastModifiedTime",
                table: "Appointments");
        }
    }
}
