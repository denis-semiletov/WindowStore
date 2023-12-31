using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WindowsStore.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderName = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "SubElements",
                columns: table => new
                {
                    SubElementId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Element = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Width = table.Column<ushort>(type: "INTEGER", nullable: false),
                    Hight = table.Column<ushort>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubElements", x => x.SubElementId);
                });

            migrationBuilder.CreateTable(
                name: "Windows",
                columns: table => new
                {
                    WindowId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WindowName = table.Column<string>(type: "TEXT", nullable: false),
                    QuantityOfWindows = table.Column<ushort>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Windows", x => x.WindowId);
                });

            migrationBuilder.CreateTable(
                name: "OrderedWindows",
                columns: table => new
                {
                    OrderedWindowId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    WindowId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedWindows", x => x.OrderedWindowId);
                    table.ForeignKey(
                        name: "FK_OrderedWindows_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedWindows_Windows_WindowId",
                        column: x => x.WindowId,
                        principalTable: "Windows",
                        principalColumn: "WindowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderedWindowSubElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderedWindowId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubElementId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedWindowSubElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderedWindowSubElements_OrderedWindows_OrderedWindowId",
                        column: x => x.OrderedWindowId,
                        principalTable: "OrderedWindows",
                        principalColumn: "OrderedWindowId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderedWindowSubElements_SubElements_SubElementId",
                        column: x => x.SubElementId,
                        principalTable: "SubElements",
                        principalColumn: "SubElementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderedWindows_OrderId",
                table: "OrderedWindows",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedWindows_WindowId",
                table: "OrderedWindows",
                column: "WindowId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedWindowSubElements_OrderedWindowId",
                table: "OrderedWindowSubElements",
                column: "OrderedWindowId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedWindowSubElements_SubElementId",
                table: "OrderedWindowSubElements",
                column: "SubElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderName",
                table: "Orders",
                column: "OrderName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Windows_WindowName",
                table: "Windows",
                column: "WindowName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderedWindowSubElements");

            migrationBuilder.DropTable(
                name: "OrderedWindows");

            migrationBuilder.DropTable(
                name: "SubElements");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Windows");
        }
    }
}
