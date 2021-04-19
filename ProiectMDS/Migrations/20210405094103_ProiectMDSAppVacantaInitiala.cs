using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectMDS.Migrations
{
    public partial class ProiectMDSAppVacantaInitiala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atractii",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Denumire = table.Column<string>(nullable: true),
                    OraDeschidere = table.Column<TimeSpan>(nullable: false),
                    OraInchidere = table.Column<TimeSpan>(nullable: false),
                    Pret = table.Column<float>(nullable: false),
                    Oras = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atractii", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cazari",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nume = table.Column<string>(nullable: true),
                    TipCazare = table.Column<string>(nullable: true),
                    DataSosire = table.Column<DateTime>(type: "Date", nullable: false),
                    DataPlecare = table.Column<DateTime>(type: "Date", nullable: false),
                    Pret = table.Column<float>(nullable: false),
                    Oras = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cazari", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Facilitati",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Denumire = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilitati", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Mancaruri",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Denumire = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mancaruri", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nume = table.Column<string>(nullable: true),
                    OraDeschidere = table.Column<TimeSpan>(nullable: false),
                    OraInchidere = table.Column<TimeSpan>(nullable: false),
                    Oras = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Utilizatori",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Nume = table.Column<string>(nullable: true),
                    Prenume = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Parola = table.Column<string>(nullable: true),
                    DataNasterii = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizatori", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vacante",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Denumire = table.Column<string>(nullable: true),
                    DataInceput = table.Column<DateTime>(type: "Date", nullable: false),
                    DataSfarsit = table.Column<DateTime>(type: "Date", nullable: false),
                    Oras = table.Column<string>(nullable: true),
                    Tara = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacante", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pachete",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CazareID = table.Column<int>(nullable: false),
                    FacilitateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pachete", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pachete_Cazari_CazareID",
                        column: x => x.CazareID,
                        principalTable: "Cazari",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pachete_Facilitati_FacilitateID",
                        column: x => x.FacilitateID,
                        principalTable: "Facilitati",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meniuri",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RestaurantID = table.Column<int>(nullable: false),
                    MancareID = table.Column<int>(nullable: false),
                    Pret = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meniuri", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Meniuri_Mancaruri_MancareID",
                        column: x => x.MancareID,
                        principalTable: "Mancaruri",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meniuri_Restaurante_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurante",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fotografii",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titlu = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    UtilizatorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotografii", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fotografii_Utilizatori_UtilizatorID",
                        column: x => x.UtilizatorID,
                        principalTable: "Utilizatori",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bilete",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VacantaID = table.Column<int>(nullable: false),
                    AtractieID = table.Column<int>(nullable: false),
                    CodBilet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilete", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bilete_Atractii_AtractieID",
                        column: x => x.AtractieID,
                        principalTable: "Atractii",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bilete_Vacante_VacantaID",
                        column: x => x.VacantaID,
                        principalTable: "Vacante",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervari",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UtilizatorID = table.Column<int>(nullable: false),
                    VacantaID = table.Column<int>(nullable: false),
                    DataRezervare = table.Column<DateTime>(type: "Date", nullable: false),
                    Review = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervari", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rezervari_Utilizatori_UtilizatorID",
                        column: x => x.UtilizatorID,
                        principalTable: "Utilizatori",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervari_Vacante_VacantaID",
                        column: x => x.VacantaID,
                        principalTable: "Vacante",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RezervariCazari",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VacantaID = table.Column<int>(nullable: false),
                    CazareID = table.Column<int>(nullable: false),
                    CodRezervare = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervariCazari", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RezervariCazari_Cazari_CazareID",
                        column: x => x.CazareID,
                        principalTable: "Cazari",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervariCazari_Vacante_VacantaID",
                        column: x => x.VacantaID,
                        principalTable: "Vacante",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicheteMasa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VacantaID = table.Column<int>(nullable: false),
                    RestaurantID = table.Column<int>(nullable: false),
                    CodTichet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicheteMasa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TicheteMasa_Restaurante_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurante",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicheteMasa_Vacante_VacantaID",
                        column: x => x.VacantaID,
                        principalTable: "Vacante",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilete_AtractieID",
                table: "Bilete",
                column: "AtractieID");

            migrationBuilder.CreateIndex(
                name: "IX_Bilete_VacantaID",
                table: "Bilete",
                column: "VacantaID");

            migrationBuilder.CreateIndex(
                name: "IX_Fotografii_UtilizatorID",
                table: "Fotografii",
                column: "UtilizatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Meniuri_MancareID",
                table: "Meniuri",
                column: "MancareID");

            migrationBuilder.CreateIndex(
                name: "IX_Meniuri_RestaurantID",
                table: "Meniuri",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_Pachete_CazareID",
                table: "Pachete",
                column: "CazareID");

            migrationBuilder.CreateIndex(
                name: "IX_Pachete_FacilitateID",
                table: "Pachete",
                column: "FacilitateID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervari_UtilizatorID",
                table: "Rezervari",
                column: "UtilizatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervari_VacantaID",
                table: "Rezervari",
                column: "VacantaID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervariCazari_CazareID",
                table: "RezervariCazari",
                column: "CazareID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervariCazari_VacantaID",
                table: "RezervariCazari",
                column: "VacantaID");

            migrationBuilder.CreateIndex(
                name: "IX_TicheteMasa_RestaurantID",
                table: "TicheteMasa",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_TicheteMasa_VacantaID",
                table: "TicheteMasa",
                column: "VacantaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilete");

            migrationBuilder.DropTable(
                name: "Fotografii");

            migrationBuilder.DropTable(
                name: "Meniuri");

            migrationBuilder.DropTable(
                name: "Pachete");

            migrationBuilder.DropTable(
                name: "Rezervari");

            migrationBuilder.DropTable(
                name: "RezervariCazari");

            migrationBuilder.DropTable(
                name: "TicheteMasa");

            migrationBuilder.DropTable(
                name: "Atractii");

            migrationBuilder.DropTable(
                name: "Mancaruri");

            migrationBuilder.DropTable(
                name: "Facilitati");

            migrationBuilder.DropTable(
                name: "Utilizatori");

            migrationBuilder.DropTable(
                name: "Cazari");

            migrationBuilder.DropTable(
                name: "Restaurante");

            migrationBuilder.DropTable(
                name: "Vacante");
        }
    }
}
