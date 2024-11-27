using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User_Api.Migrations
{
    /// <inheritdoc />
    public partial class proyectosdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imageRepositorio",
                table: "Proyectos",
                newName: "repository");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Proyectos",
                newName: "img");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "repository",
                table: "Proyectos",
                newName: "imageRepositorio");

            migrationBuilder.RenameColumn(
                name: "img",
                table: "Proyectos",
                newName: "FechaCreacion");
        }
    }
}
