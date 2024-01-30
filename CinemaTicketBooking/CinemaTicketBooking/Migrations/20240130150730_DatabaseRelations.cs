using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaTicketBooking.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FilmId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TicketId",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "RelatieClientFilm",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatieClientFilm", x => new { x.ClientId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_RelatieClientFilm_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelatieClientFilm_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FilmId",
                table: "Tickets",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TicketId",
                table: "Clients",
                column: "TicketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RelatieClientFilm_FilmId",
                table: "RelatieClientFilm",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Tickets_TicketId",
                table: "Clients",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Films_FilmId",
                table: "Tickets",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Tickets_TicketId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Films_FilmId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "RelatieClientFilm");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_FilmId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Clients_TicketId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Clients");
        }
    }
}
