using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UMicro.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Primera : Migration
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
                    nombrePermiso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreRol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tableros",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    proyectoID = table.Column<int>(type: "int", nullable: false),
                    nombreTablero = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha_creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tableros", x => x.id);
                    table.ForeignKey(
                        name: "FK_tableros_proyectos_proyectoID",
                        column: x => x.proyectoID,
                        principalTable: "proyectos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rol_Permisos",
                columns: table => new
                {
                    rolID = table.Column<int>(type: "int", nullable: false),
                    permisoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol_Permisos", x => new { x.rolID, x.permisoID });
                    table.ForeignKey(
                        name: "FK_rol_Permisos_permisos_permisoID",
                        column: x => x.permisoID,
                        principalTable: "permisos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rol_Permisos_roles_rolID",
                        column: x => x.rolID,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rolID = table.Column<int>(type: "int", nullable: false),
                    fecha_creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_id",
                        column: x => x.id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tareas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tableroID = table.Column<int>(type: "int", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    descrpcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    prioridad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_limite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fecha_creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tareas", x => x.id);
                    table.ForeignKey(
                        name: "FK_tareas_tableros_tableroID",
                        column: x => x.tableroID,
                        principalTable: "tableros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notificacions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: false),
                    tipoNotificacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    mensaje = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    fechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notificacions", x => x.id);
                    table.ForeignKey(
                        name: "FK_notificacions_usuarios_userID",
                        column: x => x.userID,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarioProyectos",
                columns: table => new
                {
                    usuarioID = table.Column<int>(type: "int", nullable: false),
                    proyectoID = table.Column<int>(type: "int", nullable: false),
                    rolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioProyectos", x => new { x.usuarioID, x.proyectoID });
                    table.ForeignKey(
                        name: "FK_usuarioProyectos_proyectos_proyectoID",
                        column: x => x.proyectoID,
                        principalTable: "proyectos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_usuarioProyectos_roles_rolID",
                        column: x => x.rolID,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_usuarioProyectos_usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comentarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tareaID = table.Column<int>(type: "int", nullable: false),
                    usuarioID = table.Column<int>(type: "int", nullable: false),
                    contenido = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    fecha_creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comentarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_comentarios_tareas_tareaID",
                        column: x => x.tareaID,
                        principalTable: "tareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comentarios_usuarios_usuarioID",
                        column: x => x.usuarioID,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recursos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tareasID = table.Column<int>(type: "int", nullable: false),
                    nombreRecurso = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    tipoRecurso = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha_creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recursos", x => x.id);
                    table.ForeignKey(
                        name: "FK_recursos_tareas_tareasID",
                        column: x => x.tareasID,
                        principalTable: "tareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subtareas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tareaID = table.Column<int>(type: "int", nullable: false),
                    tituloSb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estadoSb = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fecha_creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_modificado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subtareas", x => x.id);
                    table.ForeignKey(
                        name: "FK_subtareas_tareas_tareaID",
                        column: x => x.tareaID,
                        principalTable: "tareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_tareaID",
                table: "comentarios",
                column: "tareaID");

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_usuarioID",
                table: "comentarios",
                column: "usuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_notificacions_userID",
                table: "notificacions",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_recursos_tareasID",
                table: "recursos",
                column: "tareasID");

            migrationBuilder.CreateIndex(
                name: "IX_rol_Permisos_permisoID",
                table: "rol_Permisos",
                column: "permisoID");

            migrationBuilder.CreateIndex(
                name: "IX_subtareas_tareaID",
                table: "subtareas",
                column: "tareaID");

            migrationBuilder.CreateIndex(
                name: "IX_tableros_proyectoID",
                table: "tableros",
                column: "proyectoID");

            migrationBuilder.CreateIndex(
                name: "IX_tareas_tableroID",
                table: "tareas",
                column: "tableroID");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioProyectos_proyectoID",
                table: "usuarioProyectos",
                column: "proyectoID");

            migrationBuilder.CreateIndex(
                name: "IX_usuarioProyectos_rolID",
                table: "usuarioProyectos",
                column: "rolID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comentarios");

            migrationBuilder.DropTable(
                name: "notificacions");

            migrationBuilder.DropTable(
                name: "recursos");

            migrationBuilder.DropTable(
                name: "rol_Permisos");

            migrationBuilder.DropTable(
                name: "subtareas");

            migrationBuilder.DropTable(
                name: "usuarioProyectos");

            migrationBuilder.DropTable(
                name: "permisos");

            migrationBuilder.DropTable(
                name: "tareas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "tableros");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "proyectos");
        }
    }
}
