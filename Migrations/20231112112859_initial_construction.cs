using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace healthcare_system.Migrations
{
    /// <inheritdoc />
    public partial class initial_construction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hospitals",
                columns: table => new
                {
                    hospital_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    postal_code = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hospitals", x => x.hospital_id);
                });

            migrationBuilder.CreateTable(
                name: "medicines",
                columns: table => new
                {
                    medicine_id = table.Column<string>(type: "text", nullable: false),
                    medicine_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medicines", x => x.medicine_id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    patient_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    sex = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    age = table.Column<int>(type: "integer", nullable: false),
                    email_address = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_patients", x => x.patient_id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    department_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    floor = table.Column<string>(type: "text", nullable: false),
                    hospital_id = table.Column<string>(type: "character varying(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departments", x => x.department_id);
                    table.ForeignKey(
                        name: "fk_departments_hospitals_hospital_id",
                        column: x => x.hospital_id,
                        principalTable: "hospitals",
                        principalColumn: "hospital_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    doctor_id = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    specialization = table.Column<string>(type: "text", nullable: false),
                    department_id = table.Column<string>(type: "character varying(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_doctors", x => x.doctor_id);
                    table.ForeignKey(
                        name: "fk_doctors_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "term_reservations",
                columns: table => new
                {
                    reservation_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    reserved_by = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    patient_id = table.Column<string>(type: "character varying(50)", nullable: false),
                    doctor_id = table.Column<string>(type: "text", nullable: false),
                    term_reservation_reservation_id = table.Column<string>(type: "character varying(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_term_reservations", x => x.reservation_id);
                    table.ForeignKey(
                        name: "fk_term_reservations_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctors",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_term_reservations_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_term_reservations_term_reservations_term_reservation_reservat",
                        column: x => x.term_reservation_reservation_id,
                        principalTable: "term_reservations",
                        principalColumn: "reservation_id");
                });

            migrationBuilder.CreateTable(
                name: "consultations",
                columns: table => new
                {
                    consultation_id = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    reservation_id = table.Column<string>(type: "character varying(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_consultations", x => x.consultation_id);
                    table.ForeignKey(
                        name: "fk_consultations_term_reservations_reservation_id",
                        column: x => x.reservation_id,
                        principalTable: "term_reservations",
                        principalColumn: "reservation_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prescriptions",
                columns: table => new
                {
                    prescription_id = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    consultation_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_prescriptions", x => x.prescription_id);
                    table.ForeignKey(
                        name: "fk_prescriptions_consultations_consultation_id",
                        column: x => x.consultation_id,
                        principalTable: "consultations",
                        principalColumn: "consultation_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medicine_prescription",
                columns: table => new
                {
                    medicines_medicine_id = table.Column<string>(type: "text", nullable: false),
                    prescription_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medicine_prescription", x => new { x.medicines_medicine_id, x.prescription_id });
                    table.ForeignKey(
                        name: "fk_medicine_prescription_medicines_medicines_medicine_id",
                        column: x => x.medicines_medicine_id,
                        principalTable: "medicines",
                        principalColumn: "medicine_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_medicine_prescription_prescriptions_prescription_id",
                        column: x => x.prescription_id,
                        principalTable: "prescriptions",
                        principalColumn: "prescription_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_consultations_reservation_id",
                table: "consultations",
                column: "reservation_id");

            migrationBuilder.CreateIndex(
                name: "ix_departments_hospital_id",
                table: "departments",
                column: "hospital_id");

            migrationBuilder.CreateIndex(
                name: "ix_doctors_department_id",
                table: "doctors",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_medicine_prescription_prescription_id",
                table: "medicine_prescription",
                column: "prescription_id");

            migrationBuilder.CreateIndex(
                name: "ix_prescriptions_consultation_id",
                table: "prescriptions",
                column: "consultation_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_term_reservations_doctor_id",
                table: "term_reservations",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "ix_term_reservations_patient_id",
                table: "term_reservations",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "ix_term_reservations_term_reservation_reservation_id",
                table: "term_reservations",
                column: "term_reservation_reservation_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicine_prescription");

            migrationBuilder.DropTable(
                name: "medicines");

            migrationBuilder.DropTable(
                name: "prescriptions");

            migrationBuilder.DropTable(
                name: "consultations");

            migrationBuilder.DropTable(
                name: "term_reservations");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "hospitals");
        }
    }
}
