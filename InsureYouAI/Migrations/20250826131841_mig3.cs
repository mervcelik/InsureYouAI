using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsureYouAI.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Messages",
                newName: "MessagetDetail");

            migrationBuilder.RenameColumn(
                name: "MessageDetail",
                table: "Messages",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "IsDate",
                table: "Messages",
                newName: "IsRead");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Categories",
                newName: "CategoryName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessagetDetail",
                table: "Messages",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "IsRead",
                table: "Messages",
                newName: "IsDate");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Messages",
                newName: "MessageDetail");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Title");
        }
    }
}
