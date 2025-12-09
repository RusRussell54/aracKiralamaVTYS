using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Car_Rental_Dbms_Project.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "arac_kategorileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KategoriAd = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arac_kategorileri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ilceler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IlceAd = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ilceler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mahalleler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MahalleAd = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mahalleler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "postaKodlari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostaKoduAd = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postaKodlari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sehirler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SehirAd = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sehirler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sokaklar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SokakAd = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sokaklar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "araclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Marka = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    Yil = table.Column<int>(type: "integer", nullable: false),
                    KategoriId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_araclar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_araclar_arac_kategorileri_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "arac_kategorileri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "adresler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SokakId = table.Column<int>(type: "integer", nullable: false),
                    SehirId = table.Column<int>(type: "integer", nullable: false),
                    IlceId = table.Column<int>(type: "integer", nullable: false),
                    PostaKoduId = table.Column<int>(type: "integer", nullable: false),
                    MahalleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adresler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adresler_ilceler_IlceId",
                        column: x => x.IlceId,
                        principalTable: "ilceler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_adresler_mahalleler_MahalleId",
                        column: x => x.MahalleId,
                        principalTable: "mahalleler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_adresler_postaKodlari_PostaKoduId",
                        column: x => x.PostaKoduId,
                        principalTable: "postaKodlari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_adresler_sehirler_SehirId",
                        column: x => x.SehirId,
                        principalTable: "sehirler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_adresler_sokaklar_SokakId",
                        column: x => x.SokakId,
                        principalTable: "sokaklar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "arac_istatistikleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AracId = table.Column<int>(type: "integer", nullable: false),
                    BeygirGucu = table.Column<int>(type: "integer", nullable: false),
                    ToplamKilometre = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arac_istatistikleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_arac_istatistikleri_araclar_AracId",
                        column: x => x.AracId,
                        principalTable: "araclar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "arac_tuketim_bilgileri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AracId = table.Column<int>(type: "integer", nullable: false),
                    YakitTuru = table.Column<string>(type: "text", nullable: false),
                    YakitTuketimi = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arac_tuketim_bilgileri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_arac_tuketim_bilgileri_araclar_AracId",
                        column: x => x.AracId,
                        principalTable: "araclar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "binek_araclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    BagajHacmi = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_binek_araclar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_binek_araclar_araclar_Id",
                        column: x => x.Id,
                        principalTable: "araclar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ticari_araclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    YukKapasitesi = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticari_araclar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticari_araclar_araclar_Id",
                        column: x => x.Id,
                        principalTable: "araclar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "calisanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Soyad = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefon = table.Column<string>(type: "text", nullable: false),
                    AdresId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calisanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_calisanlar_adresler_AdresId",
                        column: x => x.AdresId,
                        principalTable: "adresler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "musteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Soyad = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefon = table.Column<string>(type: "text", nullable: false),
                    AdresId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musteriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_musteriler_adresler_AdresId",
                        column: x => x.AdresId,
                        principalTable: "adresler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kiralamalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MusteriId = table.Column<int>(type: "integer", nullable: false),
                    AracId = table.Column<int>(type: "integer", nullable: false),
                    KiralamaTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    KiralamaBitisTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kiralamalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_kiralamalar_araclar_AracId",
                        column: x => x.AracId,
                        principalTable: "araclar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_kiralamalar_musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalTable: "musteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "faturalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KiralamaId = table.Column<int>(type: "integer", nullable: false),
                    Tutar = table.Column<decimal>(type: "numeric", nullable: false),
                    FaturaTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faturalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_faturalar_kiralamalar_KiralamaId",
                        column: x => x.KiralamaId,
                        principalTable: "kiralamalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "odemeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FaturaId = table.Column<int>(type: "integer", nullable: false),
                    OdemeTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OdemeTutar = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_odemeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_odemeler_faturalar_FaturaId",
                        column: x => x.FaturaId,
                        principalTable: "faturalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "arac_kategorileri",
                columns: new[] { "Id", "KategoriAd" },
                values: new object[,]
                {
                    { 1, "Kompakt" },
                    { 2, "Sedan" },
                    { 3, "SUV" },
                    { 4, "Kamyon" },
                    { 5, "Minibüs" }
                });

            migrationBuilder.InsertData(
                table: "araclar",
                columns: new[] { "Id", "KategoriId", "Marka", "Model", "Yil" },
                values: new object[,]
                {
                    { 1, 4, "Ford", "Transit", 2023 },
                    { 2, 5, "Fiat", "Combi", 2022 },
                    { 3, 1, "Renault", "Clio", 2021 },
                    { 4, 2, "Renault", "Megane", 2023 },
                    { 5, 2, "Fiat", "Egea", 2022 },
                    { 6, 2, "Toyota", "Corolla", 2023 }
                });

            migrationBuilder.InsertData(
                table: "arac_istatistikleri",
                columns: new[] { "Id", "AracId", "BeygirGucu", "ToplamKilometre" },
                values: new object[,]
                {
                    { 1, 1, 170, 15000 },
                    { 2, 2, 145, 12000 },
                    { 3, 3, 110, 8000 },
                    { 4, 4, 130, 10000 },
                    { 5, 5, 140, 9000 },
                    { 6, 6, 140, 7000 }
                });

            migrationBuilder.InsertData(
                table: "arac_tuketim_bilgileri",
                columns: new[] { "Id", "AracId", "YakitTuketimi", "YakitTuru" },
                values: new object[,]
                {
                    { 1, 1, 9.5m, "Dizel" },
                    { 2, 2, 7.8m, "Benzin" },
                    { 3, 3, 5.5m, "Benzin" },
                    { 4, 4, 6.2m, "Benzin" },
                    { 5, 5, 6.0m, "Benzin" },
                    { 6, 6, 5.8m, "Benzin" }
                });

            migrationBuilder.InsertData(
                table: "binek_araclar",
                columns: new[] { "Id", "BagajHacmi" },
                values: new object[,]
                {
                    { 3, 260m },
                    { 4, 420m },
                    { 5, 380m },
                    { 6, 330m }
                });

            migrationBuilder.InsertData(
                table: "ticari_araclar",
                columns: new[] { "Id", "YukKapasitesi" },
                values: new object[,]
                {
                    { 1, 3500 },
                    { 2, 2800 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_adresler_IlceId",
                table: "adresler",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_adresler_MahalleId",
                table: "adresler",
                column: "MahalleId");

            migrationBuilder.CreateIndex(
                name: "IX_adresler_PostaKoduId",
                table: "adresler",
                column: "PostaKoduId");

            migrationBuilder.CreateIndex(
                name: "IX_adresler_SehirId",
                table: "adresler",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_adresler_SokakId",
                table: "adresler",
                column: "SokakId");

            migrationBuilder.CreateIndex(
                name: "IX_arac_istatistikleri_AracId",
                table: "arac_istatistikleri",
                column: "AracId");

            migrationBuilder.CreateIndex(
                name: "IX_arac_tuketim_bilgileri_AracId",
                table: "arac_tuketim_bilgileri",
                column: "AracId");

            migrationBuilder.CreateIndex(
                name: "IX_araclar_KategoriId",
                table: "araclar",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_calisanlar_AdresId",
                table: "calisanlar",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_faturalar_KiralamaId",
                table: "faturalar",
                column: "KiralamaId");

            migrationBuilder.CreateIndex(
                name: "IX_kiralamalar_AracId",
                table: "kiralamalar",
                column: "AracId");

            migrationBuilder.CreateIndex(
                name: "IX_kiralamalar_MusteriId",
                table: "kiralamalar",
                column: "MusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_musteriler_AdresId",
                table: "musteriler",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_odemeler_FaturaId",
                table: "odemeler",
                column: "FaturaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "arac_istatistikleri");

            migrationBuilder.DropTable(
                name: "arac_tuketim_bilgileri");

            migrationBuilder.DropTable(
                name: "binek_araclar");

            migrationBuilder.DropTable(
                name: "calisanlar");

            migrationBuilder.DropTable(
                name: "odemeler");

            migrationBuilder.DropTable(
                name: "ticari_araclar");

            migrationBuilder.DropTable(
                name: "faturalar");

            migrationBuilder.DropTable(
                name: "kiralamalar");

            migrationBuilder.DropTable(
                name: "araclar");

            migrationBuilder.DropTable(
                name: "musteriler");

            migrationBuilder.DropTable(
                name: "arac_kategorileri");

            migrationBuilder.DropTable(
                name: "adresler");

            migrationBuilder.DropTable(
                name: "ilceler");

            migrationBuilder.DropTable(
                name: "mahalleler");

            migrationBuilder.DropTable(
                name: "postaKodlari");

            migrationBuilder.DropTable(
                name: "sehirler");

            migrationBuilder.DropTable(
                name: "sokaklar");
        }
    }
}
