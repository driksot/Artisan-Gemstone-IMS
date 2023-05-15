using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtisanGemstoneIMS.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "CustomerAddresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "Country", "CreatedAt", "PostalCode", "State", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5550cd39-04fd-46ea-b5ec-827336ff9994"), "3705 9th Ave", "Apt. 37", "Star City", "USA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "34567", "CA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("abb58bf7-395f-4cf6-a11e-449a0a92230a"), "94 Main St.", "Ste. 2002", "Gotham City", "USA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "45678", "NJ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5a502ae-571b-4fd1-8fc5-8bb023903b39"), "123 Main St.", "Apt. 14", "Central City", "USA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12345", "MO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5bb9f11-dab1-4006-bf02-e29b6edebe5b"), "45 E Elm St.", null, "Keystone City", "USA", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "23456", "KS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "IsArchived", "Name", "Price", "Sku", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1c5ab034-4ba0-4fb5-9f07-13b06d8f155b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", "products/images/amethyst.jpg", false, "Amethyst", 22.0, "MINAMETH0000006", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4d1e2f73-94db-4559-b47b-5d7619e39dba"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "products/images/silver-wire.jpg", false, "24 Gauge Silver Wire", 7.0, "WIR24SIL0000004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4ef32bc9-536f-4231-8934-f3ce9d48d111"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "products/images/jasper.jpg", false, "Jasper", 20.0, "MINJASPE0000004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4f8e0392-db1c-4768-8a4f-c54b018f2f81"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "products/images/copper-wire.jpg", false, "26 Gauge Copper Wire", 7.0, "WIR26COP0000005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("57aea388-8f33-4975-aea7-a587855d87ee"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "products/images/agate.jpg", false, "Agate", 38.0, "MINAGATE0000007", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6b001338-1a4f-496c-8d26-dee9e111c24d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "products/images/malachite.jpg", false, "Malachite", 23.0, "MINMALAC0000009", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6f6977f5-a099-4add-94f3-1fdcb5e06b92"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "products/images/star-garnet.jpg", false, "Star Garnet", 25.0, "MINSTARG0000003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6fc19f3c-5426-4dd4-a1e2-aaebc14ce18a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "products/images/carnelian.jpg", false, "Carnelian", 18.0, "MINCARNE0000008", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7aad8902-45d5-4185-a2e6-cf466abbbb84"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", "products/images/gold-wire.jpg", false, "26 Gauge Gold Wire", 9.0, "WIR26GOL0000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9465fec5-3ee4-4d25-ba84-69f3ec21336a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "products/images/sapphire.jpg", false, "Sapphire", 25.0, "MINSAPPH0000010", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9af4201d-22d7-4579-bc40-341f345cb747"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "products/images/fire-opal.jpg", false, "Fire Opal", 18.0, "MINFIREO0000005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ae5e0036-8551-4dab-9e41-674d27b4a8b2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "products/images/gold-wire.jpg", false, "24 Gauge Gold Wire", 8.0, "WIR24GOL0000002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b8552865-4078-4e4b-8d20-ff0d14d87d8d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.", "products/images/turquoise.png", false, "Turquoise", 20.0, "MINTURQU0000002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ba12294f-779c-425e-a2d0-9a6a69e8c009"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "products/images/silver-wire.jpg", false, "26 Gauge Silver Wire", 8.0, "WIR26SIL0000003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bc7e516c-5e5b-4949-8384-414cac54e563"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.", "products/images/copper-wire.jpg", false, "24 Gauge Copper Wire", 6.0, "WIR24COP0000006", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ffbc3199-8546-4699-a532-c10a32c564cc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.", "products/images/labradorite.png", false, "Labradorite", 35.0, "MINLABRA0000001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "PhoneNumber", "PrimaryAddressId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("63b41c8e-e050-4eb2-8a21-ddee8ca8c95e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jay.garrick@flash.com", "Jay", "Garrick", "5555345678", new Guid("f5bb9f11-dab1-4006-bf02-e29b6edebe5b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c6ded20-1f31-4460-8c3c-b719c9fe0a7b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dick.grayson@nightwing.com", "Dick", "Grayson", "5555567891", new Guid("abb58bf7-395f-4cf6-a11e-449a0a92230a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9507cfc3-83f7-417f-b98e-ed8b225c159c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "wally.west@flash.com", "Wally", "West", "5555234567", new Guid("e5a502ae-571b-4fd1-8fc5-8bb023903b39"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d37a00d6-c2bd-4a52-a369-b88f1499f149"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "oliver.queen@greenarrow.com", "Oliver", "Queen", "5555456789", new Guid("5550cd39-04fd-46ea-b5ec-827336ff9994"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "CreatedAt", "IdealQuantity", "ProductId", "QuantityOnHand", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("167671fc-f78d-43cf-ba73-cdee13baf1cd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("7aad8902-45d5-4185-a2e6-cf466abbbb84"), 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("297c9f85-d80c-40e5-810f-38ace3e79155"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("6f6977f5-a099-4add-94f3-1fdcb5e06b92"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2b599210-d7ed-44e6-aa8f-8a27f0d9d057"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("ae5e0036-8551-4dab-9e41-674d27b4a8b2"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3b362269-0518-40aa-b540-cc66a2c89ba9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("6fc19f3c-5426-4dd4-a1e2-aaebc14ce18a"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("66f04724-681b-4086-8650-2359bb7357e7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("bc7e516c-5e5b-4949-8384-414cac54e563"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("845e18ef-bcba-4dd5-af16-ab50a6ef93b6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("6b001338-1a4f-496c-8d26-dee9e111c24d"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8601d89f-fcb0-4575-9814-ec813127d1ce"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("57aea388-8f33-4975-aea7-a587855d87ee"), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8917aa6d-2655-4108-a520-b0da674bc44c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("ffbc3199-8546-4699-a532-c10a32c564cc"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("999d4d12-8d9d-4315-a389-16b210e28dbd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("b8552865-4078-4e4b-8d20-ff0d14d87d8d"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("afcd2641-40ae-4e23-afbc-0266e68ee293"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("4ef32bc9-536f-4231-8934-f3ce9d48d111"), 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3f5dc4d-0a08-44c4-8248-88e0f984662f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("9af4201d-22d7-4579-bc40-341f345cb747"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b71b18b6-cd89-4ab8-9bf1-8aa662ae36a1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("1c5ab034-4ba0-4fb5-9f07-13b06d8f155b"), 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bb1d4d10-153a-47c5-9751-9413f4a3f7fc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("9465fec5-3ee4-4d25-ba84-69f3ec21336a"), 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cb7a6bf2-c1e1-44e5-8b0a-c6b4723f32ce"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("4d1e2f73-94db-4559-b47b-5d7619e39dba"), 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd659b08-d7ae-438e-935b-729bdef5c54f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("4f8e0392-db1c-4768-8a4f-c54b018f2f81"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fe0bf302-19b3-46f0-95b5-1c5f32734071"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, new Guid("ba12294f-779c-425e-a2d0-9a6a69e8c009"), 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("63b41c8e-e050-4eb2-8a21-ddee8ca8c95e"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("7c6ded20-1f31-4460-8c3c-b719c9fe0a7b"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("9507cfc3-83f7-417f-b98e-ed8b225c159c"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("d37a00d6-c2bd-4a52-a369-b88f1499f149"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("167671fc-f78d-43cf-ba73-cdee13baf1cd"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("297c9f85-d80c-40e5-810f-38ace3e79155"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("2b599210-d7ed-44e6-aa8f-8a27f0d9d057"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("3b362269-0518-40aa-b540-cc66a2c89ba9"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("66f04724-681b-4086-8650-2359bb7357e7"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("845e18ef-bcba-4dd5-af16-ab50a6ef93b6"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("8601d89f-fcb0-4575-9814-ec813127d1ce"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("8917aa6d-2655-4108-a520-b0da674bc44c"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("999d4d12-8d9d-4315-a389-16b210e28dbd"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("afcd2641-40ae-4e23-afbc-0266e68ee293"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("b3f5dc4d-0a08-44c4-8248-88e0f984662f"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("b71b18b6-cd89-4ab8-9bf1-8aa662ae36a1"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("bb1d4d10-153a-47c5-9751-9413f4a3f7fc"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("cb7a6bf2-c1e1-44e5-8b0a-c6b4723f32ce"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("cd659b08-d7ae-438e-935b-729bdef5c54f"));

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: new Guid("fe0bf302-19b3-46f0-95b5-1c5f32734071"));

            migrationBuilder.DeleteData(
                table: "CustomerAddresses",
                keyColumn: "Id",
                keyValue: new Guid("5550cd39-04fd-46ea-b5ec-827336ff9994"));

            migrationBuilder.DeleteData(
                table: "CustomerAddresses",
                keyColumn: "Id",
                keyValue: new Guid("abb58bf7-395f-4cf6-a11e-449a0a92230a"));

            migrationBuilder.DeleteData(
                table: "CustomerAddresses",
                keyColumn: "Id",
                keyValue: new Guid("e5a502ae-571b-4fd1-8fc5-8bb023903b39"));

            migrationBuilder.DeleteData(
                table: "CustomerAddresses",
                keyColumn: "Id",
                keyValue: new Guid("f5bb9f11-dab1-4006-bf02-e29b6edebe5b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1c5ab034-4ba0-4fb5-9f07-13b06d8f155b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4d1e2f73-94db-4559-b47b-5d7619e39dba"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4ef32bc9-536f-4231-8934-f3ce9d48d111"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4f8e0392-db1c-4768-8a4f-c54b018f2f81"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("57aea388-8f33-4975-aea7-a587855d87ee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6b001338-1a4f-496c-8d26-dee9e111c24d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f6977f5-a099-4add-94f3-1fdcb5e06b92"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6fc19f3c-5426-4dd4-a1e2-aaebc14ce18a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7aad8902-45d5-4185-a2e6-cf466abbbb84"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9465fec5-3ee4-4d25-ba84-69f3ec21336a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9af4201d-22d7-4579-bc40-341f345cb747"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ae5e0036-8551-4dab-9e41-674d27b4a8b2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b8552865-4078-4e4b-8d20-ff0d14d87d8d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ba12294f-779c-425e-a2d0-9a6a69e8c009"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bc7e516c-5e5b-4949-8384-414cac54e563"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffbc3199-8546-4699-a532-c10a32c564cc"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");
        }
    }
}
