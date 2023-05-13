using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blackbird.Persistence.Migrations;

/// <inheritdoc />
public partial class AddProductId : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "ProductId",
            table: "Products",
            type: "nvarchar(max)",
            nullable: false,
            defaultValue: "");

        migrationBuilder.UpdateData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 1,
            column: "ProductId",
            value: "d9d3857d-17a4-4acd-8e82-dbe87510f26c");

        migrationBuilder.UpdateData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 2,
            column: "ProductId",
            value: "fc142e5a-d247-4b25-8295-c86317146043");

        migrationBuilder.UpdateData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 3,
            column: "ProductId",
            value: "0cc082ec-754d-4fb3-837e-c1d7e3086e75");

        migrationBuilder.UpdateData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 4,
            column: "ProductId",
            value: "b7f83fe2-461f-4dee-9ca2-74ca00454d32");

        migrationBuilder.UpdateData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 5,
            column: "ProductId",
            value: "eb8b8c2b-37c1-4dde-b60d-4402d4114e54");

        migrationBuilder.UpdateData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 6,
            column: "ProductId",
            value: "c9b7f15f-79de-4d8b-af68-62e3197ca2ee");

        migrationBuilder.UpdateData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 7,
            column: "ProductId",
            value: "2c2affc1-5228-462c-ad98-61dd1570c47b");

        migrationBuilder.UpdateData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 8,
            column: "ProductId",
            value: "48e57660-6b9b-4348-a472-d87047a1638f");

        migrationBuilder.UpdateData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 9,
            column: "ProductId",
            value: "18d431a8-d17a-428e-a519-3a9526228d70");

        migrationBuilder.UpdateData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 10,
            column: "ProductId",
            value: "2ff61626-363f-482b-b465-8acedb8424b9");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "ProductId",
            table: "Products");
    }
}
