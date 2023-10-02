using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherForecastAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDateTimeToApiCallDataPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StoredApiCallData",
                table: "StoredApiCallData");

            migrationBuilder.RenameColumn(
                name: "JsonData",
                table: "StoredApiCallData",
                newName: "CallJsonData");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "StoredApiCallData",
                newName: "CallUrl");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StoredApiCallData",
                newName: "ApiName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoredApiCallData",
                table: "StoredApiCallData",
                columns: new[] { "ApiName", "CallUrl", "CallDateTime" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StoredApiCallData",
                table: "StoredApiCallData");

            migrationBuilder.RenameColumn(
                name: "CallJsonData",
                table: "StoredApiCallData",
                newName: "JsonData");

            migrationBuilder.RenameColumn(
                name: "CallUrl",
                table: "StoredApiCallData",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "ApiName",
                table: "StoredApiCallData",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoredApiCallData",
                table: "StoredApiCallData",
                columns: new[] { "Name", "Url" });
        }
    }
}
