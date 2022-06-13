using Microsoft.EntityFrameworkCore.Migrations;

namespace MyStore.Data.Migrations
{
    public partial class RelationsOneMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrder_Customers_CustomersId",
                table: "CustomerOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrder_Orders_OrdersId",
                table: "CustomerOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_FidelityCards_Customers_CustomerId",
                table: "FidelityCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af535123-38db-488b-9363-98db86e0aa3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4e491b1-e1ef-46ac-889a-63f48172a19a");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "CustomerOrder",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "CustomersId",
                table: "CustomerOrder",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerOrder_OrdersId",
                table: "CustomerOrder",
                newName: "IX_CustomerOrder_OrderId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d8cc3f77-d204-411c-956b-0a7c9e986c32", "cfb31678-c02e-4e41-9752-d3c4019a6735", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb3a5771-9217-4035-a7cd-d8aabb561211", "276fb4a5-5a04-4891-8d8e-46ba703e8fad", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerId_CustomerOrder",
                table: "CustomerOrder",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderId_CustomerOrder",
                table: "CustomerOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerId_FidelityCard",
                table: "FidelityCards",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryId_Product",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerId_CustomerOrder",
                table: "CustomerOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderId_CustomerOrder",
                table: "CustomerOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerId_FidelityCard",
                table: "FidelityCards");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryId_Product",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8cc3f77-d204-411c-956b-0a7c9e986c32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb3a5771-9217-4035-a7cd-d8aabb561211");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "CustomerOrder",
                newName: "OrdersId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "CustomerOrder",
                newName: "CustomersId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerOrder_OrderId",
                table: "CustomerOrder",
                newName: "IX_CustomerOrder_OrdersId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af535123-38db-488b-9363-98db86e0aa3c", "4ee19bc9-4708-4940-af60-7e7b5086be64", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e4e491b1-e1ef-46ac-889a-63f48172a19a", "bfe4c946-a4e7-4126-9a28-5b4686526426", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrder_Customers_CustomersId",
                table: "CustomerOrder",
                column: "CustomersId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrder_Orders_OrdersId",
                table: "CustomerOrder",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FidelityCards_Customers_CustomerId",
                table: "FidelityCards",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
