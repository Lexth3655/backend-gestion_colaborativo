using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMicro.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PrimerAvacnce : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "permisos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcionP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permisos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "proyectos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreProyecto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcionProyecto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proyectos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rols",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreRol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcionRol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rols", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tableroKanbans",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreTablero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    proyecto_id = table.Column<int>(type: "int", nullable: false),
                    fecha_creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tableroKanbans", x => x.id);
                    table.ForeignKey(
                        name: "FK_tableroKanbans_proyectos_proyecto_id",
                        column: x => x.proyecto_id,
                        principalTable: "proyectos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rol_Permisos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_rol = table.Column<int>(type: "int", nullable: false),
                    id_permiso = table.Column<int>(type: "int", nullable: false),
                    rolid = table.Column<int>(type: "int", nullable: false),
                    rol_Permisoid = table.Column<int>(type: "int", nullable: false),
                    fecha_creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol_Permisos", x => x.id);
                    table.ForeignKey(
                        name: "FK_rol_Permisos_rol_Permisos_rol_Permisoid",
                        column: x => x.rol_Permisoid,
                        principalTable: "rol_Permisos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rol_Permisos_rols_rolid",
                        column: x => x.rolid,
                        principalTable: "rols",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nombreU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anioCreado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rolID = table.Column<int>(type: "int", nullable: false),
                    fecha_creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_rols_id",
                        column: x => x.id,
                        principalTable: "rols",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tareas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descrpcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prioridad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_limite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estadoT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    recurrente = table.Column<int>(type: "int", nullable: false),
                    tiempo_invertido = table.Column<int>(type: "int", nullable: false),
                    id_proyecto = table.Column<int>(type: "int", nullable: false),
                    id_usuario_propietario = table.Column<int>(type: "int", nullable: false),
                    tablero_id = table.Column<int>(type: "int", nullable: false),
                    fecha_creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tareas", x => x.id);
                    table.ForeignKey(
                        name: "FK_tareas_tableroKanbans_tablero_id",
                        column: x => x.tablero_id,
                        principalTable: "tableroKanbans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "proyectoUsuarioRols",
                columns: table => new
                {
                    proyecto_id = table.Column<int>(type: "int", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    rol_id = table.Column<int>(type: "int", nullable: false),
                    proyectoPURid = table.Column<int>(type: "int", nullable: false),
                    rolPURid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proyectoUsuarioRols", x => new { x.proyecto_id, x.usuario_id, x.rol_id });
                    table.ForeignKey(
                        name: "FK_proyectoUsuarioRols_proyectos_proyectoPURid",
                        column: x => x.proyectoPURid,
                        principalTable: "proyectos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_proyectoUsuarioRols_rols_rolPURid",
                        column: x => x.rolPURid,
                        principalTable: "rols",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_proyectoUsuarioRols_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sub_Tarea",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tituloSb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estadoSb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_tarea = table.Column<int>(type: "int", nullable: false),
                    tareaid = table.Column<int>(type: "int", nullable: false),
                    fecha_creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sub_Tarea", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sub_Tarea_tareas_tareaid",
                        column: x => x.tareaid,
                        principalTable: "tareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_proyectoUsuarioRols_proyectoPURid",
                table: "proyectoUsuarioRols",
                column: "proyectoPURid");

            migrationBuilder.CreateIndex(
                name: "IX_proyectoUsuarioRols_rolPURid",
                table: "proyectoUsuarioRols",
                column: "rolPURid");

            migrationBuilder.CreateIndex(
                name: "IX_proyectoUsuarioRols_usuario_id",
                table: "proyectoUsuarioRols",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_rol_Permisos_rol_Permisoid",
                table: "rol_Permisos",
                column: "rol_Permisoid");

            migrationBuilder.CreateIndex(
                name: "IX_rol_Permisos_rolid",
                table: "rol_Permisos",
                column: "rolid");

            migrationBuilder.CreateIndex(
                name: "IX_Sub_Tarea_tareaid",
                table: "Sub_Tarea",
                column: "tareaid");

            migrationBuilder.CreateIndex(
                name: "IX_tableroKanbans_proyecto_id",
                table: "tableroKanbans",
                column: "proyecto_id");

            migrationBuilder.CreateIndex(
                name: "IX_tareas_tablero_id",
                table: "tareas",
                column: "tablero_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "permisos");

            migrationBuilder.DropTable(
                name: "proyectoUsuarioRols");

            migrationBuilder.DropTable(
                name: "rol_Permisos");

            migrationBuilder.DropTable(
                name: "Sub_Tarea");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "tareas");

            migrationBuilder.DropTable(
                name: "rols");

            migrationBuilder.DropTable(
                name: "tableroKanbans");

            migrationBuilder.DropTable(
                name: "proyectos");
        }
    }
}
