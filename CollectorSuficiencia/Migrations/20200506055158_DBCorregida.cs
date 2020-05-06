using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CollectorSuficiencia.Migrations
{
    public partial class DBCorregida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoUsuario = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Puntuacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provincia = table.Column<string>(nullable: false),
                    Canton = table.Column<string>(nullable: false),
                    Distrito = table.Column<string>(nullable: false),
                    DireccionExacta = table.Column<string>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Direcciones_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Intereses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descipcion = table.Column<string>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intereses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Intereses_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPago",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPago", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MetodoPago_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Puntuacion = table.Column<int>(nullable: false),
                    PrecioOfera = table.Column<double>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    Calificacion = table.Column<int>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ofertas_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subastas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioBase = table.Column<double>(nullable: false),
                    Puntuacion = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Finaliza = table.Column<DateTime>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subastas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Subastas_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenCompras",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDSubastaID = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    FechaOrden = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenCompras", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrdenCompras_Subastas_IDSubastaID",
                        column: x => x.IDSubastaID,
                        principalTable: "Subastas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    FechaCompra = table.Column<DateTime>(nullable: false),
                    Antiguedad = table.Column<string>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false),
                    SubastaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Producto_Subastas_SubastaID",
                        column: x => x.SubastaID,
                        principalTable: "Subastas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Producto_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_UsuarioID",
                table: "Direcciones",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Intereses_UsuarioID",
                table: "Intereses",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_MetodoPago_UsuarioID",
                table: "MetodoPago",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_UsuarioID",
                table: "Ofertas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompras_IDSubastaID",
                table: "OrdenCompras",
                column: "IDSubastaID");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_SubastaID",
                table: "Producto",
                column: "SubastaID");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_UsuarioID",
                table: "Producto",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Subastas_UsuarioID",
                table: "Subastas",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "Intereses");

            migrationBuilder.DropTable(
                name: "MetodoPago");

            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.DropTable(
                name: "OrdenCompras");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Subastas");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
