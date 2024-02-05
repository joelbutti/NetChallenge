using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetChallenge.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class valueObjectsEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Offices_LocationId_Name",
                table: "Offices");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_OfficeId_DateTime_Duration",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_LocationId",
                table: "Offices",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_Name",
                table: "Offices",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_OfficeId",
                table: "Bookings",
                column: "OfficeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Offices_LocationId",
                table: "Offices");

            migrationBuilder.DropIndex(
                name: "IX_Offices_Name",
                table: "Offices");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_OfficeId",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_LocationId_Name",
                table: "Offices",
                columns: new[] { "LocationId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_OfficeId_DateTime_Duration",
                table: "Bookings",
                columns: new[] { "OfficeId", "DateTime", "Duration" },
                unique: true);
        }
    }
}
