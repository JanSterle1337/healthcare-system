using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace healthcare_system.Migrations
{
    /// <inheritdoc />
    public partial class doctor_change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_doctors_departments_department_id",
                table: "doctors");

            migrationBuilder.DropForeignKey(
                name: "fk_term_reservations_doctors_doctor_id",
                table: "term_reservations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_doctors",
                table: "doctors");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "term_reservations",
                newName: "term_reservations",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "prescriptions",
                newName: "prescriptions",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "patients",
                newName: "patients",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "medicines",
                newName: "medicines",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "medicine_prescription",
                newName: "medicine_prescription",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "hospitals",
                newName: "hospitals",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "departments",
                newName: "departments",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "consultations",
                newName: "consultations",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "doctors",
                newName: "AspNetUsers",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "doctor_id",
                schema: "public",
                table: "AspNetUsers",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "ix_doctors_department_id",
                schema: "public",
                table: "AspNetUsers",
                newName: "ix_asp_net_users_department_id");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                schema: "public",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "access_failed_count",
                schema: "public",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "concurrency_stamp",
                schema: "public",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "email_confirmed",
                schema: "public",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "lockout_enabled",
                schema: "public",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "lockout_end",
                schema: "public",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "normalized_email",
                schema: "public",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "normalized_user_name",
                schema: "public",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password_hash",
                schema: "public",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "phone_number_confirmed",
                schema: "public",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "security_stamp",
                schema: "public",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "two_factor_enabled",
                schema: "public",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "user_name",
                schema: "public",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_users",
                schema: "public",
                table: "AspNetUsers",
                column: "id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "public",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "public",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<string>(type: "text", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "public",
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "public",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    role_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "public",
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "public",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "public",
                table: "AspNetUsers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "public",
                table: "AspNetUsers",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_role_claims_role_id",
                schema: "public",
                table: "AspNetRoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "public",
                table: "AspNetRoles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                schema: "public",
                table: "AspNetUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                schema: "public",
                table: "AspNetUserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                schema: "public",
                table: "AspNetUserRoles",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_users_departments_department_id",
                schema: "public",
                table: "AspNetUsers",
                column: "department_id",
                principalSchema: "public",
                principalTable: "departments",
                principalColumn: "department_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_term_reservations_doctor_doctor_id",
                schema: "public",
                table: "term_reservations",
                column: "doctor_id",
                principalSchema: "public",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_users_departments_department_id",
                schema: "public",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "fk_term_reservations_doctor_doctor_id",
                schema: "public",
                table: "term_reservations");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "public");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_users",
                schema: "public",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                schema: "public",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                schema: "public",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "access_failed_count",
                schema: "public",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "concurrency_stamp",
                schema: "public",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "email_confirmed",
                schema: "public",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "lockout_enabled",
                schema: "public",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "lockout_end",
                schema: "public",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "normalized_email",
                schema: "public",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "normalized_user_name",
                schema: "public",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "password_hash",
                schema: "public",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "phone_number_confirmed",
                schema: "public",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "security_stamp",
                schema: "public",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "two_factor_enabled",
                schema: "public",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "user_name",
                schema: "public",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "term_reservations",
                schema: "public",
                newName: "term_reservations");

            migrationBuilder.RenameTable(
                name: "prescriptions",
                schema: "public",
                newName: "prescriptions");

            migrationBuilder.RenameTable(
                name: "patients",
                schema: "public",
                newName: "patients");

            migrationBuilder.RenameTable(
                name: "medicines",
                schema: "public",
                newName: "medicines");

            migrationBuilder.RenameTable(
                name: "medicine_prescription",
                schema: "public",
                newName: "medicine_prescription");

            migrationBuilder.RenameTable(
                name: "hospitals",
                schema: "public",
                newName: "hospitals");

            migrationBuilder.RenameTable(
                name: "departments",
                schema: "public",
                newName: "departments");

            migrationBuilder.RenameTable(
                name: "consultations",
                schema: "public",
                newName: "consultations");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "public",
                newName: "doctors");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "doctors",
                newName: "doctor_id");

            migrationBuilder.RenameIndex(
                name: "ix_asp_net_users_department_id",
                table: "doctors",
                newName: "ix_doctors_department_id");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "doctors",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "pk_doctors",
                table: "doctors",
                column: "doctor_id");

            migrationBuilder.AddForeignKey(
                name: "fk_doctors_departments_department_id",
                table: "doctors",
                column: "department_id",
                principalTable: "departments",
                principalColumn: "department_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_term_reservations_doctors_doctor_id",
                table: "term_reservations",
                column: "doctor_id",
                principalTable: "doctors",
                principalColumn: "doctor_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
