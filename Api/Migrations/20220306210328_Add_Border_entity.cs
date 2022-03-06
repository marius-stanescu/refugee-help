using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Api.Migrations
{
    public partial class Add_Border_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartingPoint",
                table: "Transport");

            migrationBuilder.AddColumn<int>(
                name: "BorderId",
                table: "Transport",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "Border",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Border", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Border",
                columns: new[] { "Id", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "Vama Sighetu Marmației/Solotvino", "VAMA_SIGHETU_MARMATIEI_SOLOTVINO" },
                    { 2, "Vama Vicșani/Vadu Siret", "VAMA_VICSANI_VADU_SIRET" },
                    { 3, "Vama Isaccea/Orlovka", "VAMA_ISACCEA_ORLOVKA" },
                    { 4, "Vama Tulcea/Ismail", "VAMA_TULCEA_ISMAIL" },
                    { 5, "Vama Câmpulung la Tisa/Teresova", "VAMA_CAMPULUNG_LA_TISA_TERESOVA" },
                    { 6, "Vama Sculeni", "VAMA_SCULENI" },
                    { 7, "Vama Stânca/Costești", "VAMA_STANCA_COSTESTI" },
                    { 8, "Vama Albița/Leușeni", "VAMA_ALBITA_LEUSENI" },
                    { 9, "Vama Galați/Giurgiulești", "VAMA_GALATI_GIURGIULESTI" },
                    { 10, "Vama Fălciu/Stoianovca", "VAMA_FALCIU_STOIANOVCA" },
                    { 11, "Vama Nicolina/Ungheni", "VAMA_NICOLINA_UNGHENI" },
                    { 12, "Vama Oancea/Cahul", "VAMA_OANCEA_CAHUL" },
                    { 13, "Vama Bechet/Rahova (Orjahovo)", "VAMA_BECHET_RAHOVA_ORJAHOVO_" },
                    { 14, "Vama Borș/Ártánd", "VAMA_BORS_ÁRTÁND" },
                    { 15, "Vama Calafat/Vidin", "VAMA_CALAFAT_VIDIN" },
                    { 16, "Vama Călărași/Silistra", "VAMA_CALARASI_SILISTRA" },
                    { 17, "Vama Capul Midia", "VAMA_CAPUL_MIDIA" },
                    { 18, "Vama Carei/Vallaj", "VAMA_CAREI_VALLAJ" },
                    { 19, "Vama Cenad/Kiszombor", "VAMA_CENAD_KISZOMBOR" },
                    { 20, "Vama Corabia/Măgura", "VAMA_CORABIA_MAGURA" },
                    { 21, "Vama Curtici/Lőkösháza", "VAMA_CURTICI_LŐKÖSHÁZA" },
                    { 22, "Vama Episcopia Bihor/Biharkeresztes", "VAMA_EPISCOPIA_BIHOR_BIHARKERESZTES" },
                    { 23, "Vama Giurgiu/Ruse", "VAMA_GIURGIU_RUSE" },
                    { 25, "Vama Jimbolia/Kikinda Crinja", "VAMA_JIMBOLIA_KIKINDA_CRINJA" },
                    { 26, "Vama Lipnița/Kainargea", "VAMA_LIPNITA_KAINARGEA" },
                    { 27, "Vama Constanța", "VAMA_CONSTANTA" },
                    { 28, "Vama Mangalia", "VAMA_MANGALIA" },
                    { 29, "Vama Sulina", "VAMA_SULINA" },
                    { 30, "Vama Brăila", "VAMA_BRAILA" },
                    { 31, "Vama Cernavodă", "VAMA_CERNAVODA" },
                    { 32, "Vama Drobeta Turnu Severin", "VAMA_DROBETA_TURNU_SEVERIN" },
                    { 33, "Vama Moldova Veche/Gerdap", "VAMA_MOLDOVA_VECHE_GERDAP" },
                    { 34, "Vama Naidăș/Kalugerovo", "VAMA_NAIDAS_KALUGEROVO" },
                    { 35, "Vama Nădlac/Nagylak", "VAMA_NADLAC_NAGYLAK" },
                    { 36, "Vama Oltenița/Turtucaia (Tutrakan)", "VAMA_OLTENITA_TURTUCAIA_TUTRAKAN_" },
                    { 37, "Vama Orșova", "VAMA_ORSOVA" },
                    { 38, "Vama Ostrov/Silistra", "VAMA_OSTROV_SILISTRA" },
                    { 39, "Vama Petea/Csengersima", "VAMA_PETEA_CSENGERSIMA" },
                    { 40, "Vama Porțile de Fier I/Djerdap I", "VAMA_PORTILE_DE_FIER_I_DJERDAP_I" },
                    { 41, "Vama Porțile de Fier II/Punctul Djerdap II", "VAMA_PORTILE_DE_FIER_II_PUNCTUL_DJERDAP_II" },
                    { 42, "Vama Salonta/Méhkerék", "VAMA_SALONTA_MÉHKERÉK" },
                    { 43, "Vama Săcuieni/Letavertes", "VAMA_SACUIENI_LETAVERTES" }
                });

            migrationBuilder.InsertData(
                table: "Border",
                columns: new[] { "Id", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 44, "Vama Stamora-Moravița/Varsac Vatin", "VAMA_STAMORA_MORAVITA_VARSAC_VATIN" },
                    { 45, "Vama Turnu/Battonya", "VAMA_TURNU_BATTONYA" },
                    { 46, "Vama Turnu Măgurele/Nicopole", "VAMA_TURNU_MAGURELE_NICOPOLE" },
                    { 47, "Vama Urziceni/Vallaj", "VAMA_URZICENI_VALLAJ" },
                    { 48, "Vama Valea lui Mihai/Nyírábrány", "VAMA_VALEA_LUI_MIHAI_NYÍRÁBRÁNY" },
                    { 49, "Vama Vama Veche/Durankulak", "VAMA_VAMA_VECHE_DURANKULAK" },
                    { 50, "Vama Vărșand/Gyula", "VAMA_VARSAND_GYULA" },
                    { 51, "Vama Vladimirescu/Lőkösháza", "VAMA_VLADIMIRESCU_LŐKÖSHÁZA" },
                    { 52, "Vama Zimnicea/Sviștov", "VAMA_ZIMNICEA_SVISTOV" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transport_BorderId",
                table: "Transport",
                column: "BorderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transport_Border_BorderId",
                table: "Transport",
                column: "BorderId",
                principalTable: "Border",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transport_Border_BorderId",
                table: "Transport");

            migrationBuilder.DropTable(
                name: "Border");

            migrationBuilder.DropIndex(
                name: "IX_Transport_BorderId",
                table: "Transport");

            migrationBuilder.DropColumn(
                name: "BorderId",
                table: "Transport");

            migrationBuilder.AddColumn<string>(
                name: "StartingPoint",
                table: "Transport",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
