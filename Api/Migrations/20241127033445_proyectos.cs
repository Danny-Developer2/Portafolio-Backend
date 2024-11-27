using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User_Api.Migrations
{
    /// <inheritdoc />
    public partial class proyectos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RepositorioGithub",
                table: "Proyectos",
                newName: "startDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Proyectos",
                newName: "RepositorioGithub");
        }
    }
}
