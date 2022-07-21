using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VolkDiet.Core.Migrations.PgSql
{
    public partial class InitialDbPgSql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LAFParameters",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LAF_Alg = table.Column<string>(type: "character varying(1)", unicode: false, maxLength: 1, nullable: false),
                    LAF_Sex = table.Column<string>(type: "character varying(1)", unicode: false, maxLength: 1, nullable: false),
                    LAF_AgeMin = table.Column<int>(type: "integer", nullable: false),
                    LAF_AgeMax = table.Column<int>(type: "integer", nullable: false),
                    LAF_Lvl = table.Column<int>(type: "integer", nullable: false),
                    LAF_Value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LAFParameters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LAN_Name = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    LAN_Culture = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    LAN_ImageName = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true),
                    LAN_DisplayOrder = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LIB_Desc = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ROL_Desc = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LocalizedStrings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LAN_ID = table.Column<int>(type: "integer", nullable: true),
                    RES_Name = table.Column<string>(type: "character varying(250)", unicode: false, maxLength: 250, nullable: true),
                    RES_Value = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedStrings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LocalizedStrings_Languages",
                        column: x => x.LAN_ID,
                        principalTable: "Languages",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LocalizedTables",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LAN_ID = table.Column<int>(type: "integer", nullable: true),
                    LTB_Table = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    LTB_Property = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    LTB_RecordID = table.Column<int>(type: "integer", nullable: true),
                    LTB_Value = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedTables", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LocalizedTables_Languages",
                        column: x => x.LAN_ID,
                        principalTable: "Languages",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LIB_ID = table.Column<int>(type: "integer", nullable: false),
                    CAT_Desc = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categories_Libraries",
                        column: x => x.LIB_ID,
                        principalTable: "Libraries",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LIB_ID = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TEN_Desc = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true),
                    TEN_IsTemplate = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tenants_Libraries",
                        column: x => x.LIB_ID,
                        principalTable: "Libraries",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RolesClaims",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ROL_ID = table.Column<int>(type: "integer", nullable: true),
                    RCL_Name = table.Column<string>(type: "text", unicode: false, nullable: true),
                    RCL_Value = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesClaims", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RolesClaims_Roles",
                        column: x => x.ROL_ID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Aliments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ALI_Desc = table.Column<string>(type: "character varying(250)", unicode: false, maxLength: 250, nullable: true),
                    LIB_ID = table.Column<int>(type: "integer", nullable: true),
                    CAT_ID = table.Column<int>(type: "integer", nullable: true),
                    ALI_K = table.Column<double>(type: "double precision", nullable: true, defaultValueSql: "((100))"),
                    ALI_LastMod = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ALI_KCal = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Protein = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Lipids = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Choleterol = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Glucides = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Starch = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Fiber = table.Column<double>(type: "double precision", nullable: true),
                    ALI_FibelSol = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Alcool = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Water = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Iron = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Calcium = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Sodium = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Potassium = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Phosphorus = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Zinc = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Magnesium = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Copper = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Selenium = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Chlorine = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Iudium = table.Column<double>(type: "double precision", nullable: true),
                    ALI_TiaminaB1 = table.Column<double>(type: "double precision", nullable: true),
                    ALI_RiboflavinaB2 = table.Column<double>(type: "double precision", nullable: true),
                    ALI_VitC = table.Column<double>(type: "double precision", nullable: true),
                    ALI_NiacinaB3 = table.Column<double>(type: "double precision", nullable: true),
                    ALI_VitB6 = table.Column<double>(type: "double precision", nullable: true),
                    ALI_VitB12 = table.Column<double>(type: "double precision", nullable: true),
                    ALI_VitAReteq = table.Column<double>(type: "double precision", nullable: true),
                    ALI_VitEReteq = table.Column<double>(type: "double precision", nullable: true),
                    ALI_VitE = table.Column<double>(type: "double precision", nullable: true),
                    ALI_ASatur = table.Column<double>(type: "double precision", nullable: true),
                    ALI_APoly = table.Column<double>(type: "double precision", nullable: true),
                    ALI_AMono = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Glucose = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Fructose = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Galactose = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Sucrose = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Maltose = table.Column<double>(type: "double precision", nullable: true),
                    ALI_Lactose = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Aliments_Categories",
                        column: x => x.CAT_ID,
                        principalTable: "Categories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Aliments_Libraries",
                        column: x => x.LIB_ID,
                        principalTable: "Libraries",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TEN_ID = table.Column<int>(type: "integer", nullable: false),
                    MEA_Desc = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Meals_Tenants1",
                        column: x => x.TEN_ID,
                        principalTable: "Tenants",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TEN_ID = table.Column<int>(type: "integer", nullable: false),
                    LAN_ID = table.Column<int>(type: "integer", nullable: true),
                    USR_Login = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    USR_Email = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    USR_DtReg = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    USR_Step = table.Column<string>(type: "character varying(1)", unicode: false, maxLength: 1, nullable: true),
                    USR_PwdHash = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Languages",
                        column: x => x.LAN_ID,
                        principalTable: "Languages",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_Tenants",
                        column: x => x.TEN_ID,
                        principalTable: "Tenants",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DietTemplates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TEN_ID = table.Column<int>(type: "integer", nullable: false),
                    TEM_Desc = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    TEM_PercCarbs = table.Column<double>(type: "double precision", nullable: true),
                    TEM_PercProts = table.Column<double>(type: "double precision", nullable: true),
                    TEM_PercFats = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietTemplates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DietTemplates_Meals",
                        column: x => x.TEN_ID,
                        principalTable: "Meals",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Checkups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    USR_ID = table.Column<int>(type: "integer", nullable: false),
                    CUP_Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CUP_Heigth = table.Column<double>(type: "double precision", nullable: true),
                    CUP_Weight = table.Column<double>(type: "double precision", nullable: true),
                    CUP_LeanMass = table.Column<double>(type: "double precision", nullable: true),
                    CUP_FatMass = table.Column<double>(type: "double precision", nullable: true),
                    CUP_Mis1 = table.Column<double>(type: "double precision", nullable: true),
                    CUP_Mis2 = table.Column<double>(type: "double precision", nullable: true),
                    CUP_Mis3 = table.Column<double>(type: "double precision", nullable: true),
                    CUP_Mis4 = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Checkups_Users",
                        column: x => x.USR_ID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TEN_ID = table.Column<int>(type: "integer", nullable: false),
                    USR_ID = table.Column<int>(type: "integer", nullable: false),
                    DIE_Desc = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    DIE_Note = table.Column<string>(type: "character varying(200)", unicode: false, maxLength: 200, nullable: true),
                    DIE_Requirement = table.Column<int>(type: "integer", nullable: true),
                    DIE_LastMod = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DIE_PerCarbs = table.Column<double>(type: "double precision", nullable: true),
                    DIE_PerProts = table.Column<double>(type: "double precision", nullable: true),
                    DIE_PerFats = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Diets_Tenants",
                        column: x => x.TEN_ID,
                        principalTable: "Tenants",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Diets_Users",
                        column: x => x.USR_ID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "FoodIntollerances",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    USR_ID = table.Column<int>(type: "integer", nullable: false),
                    FIN_Desc = table.Column<string>(type: "text", unicode: false, nullable: false),
                    FIN_Severity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodIntollerances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FoodIntollerances_Users",
                        column: x => x.USR_ID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    USR_ID = table.Column<int>(type: "integer", nullable: true),
                    ROL_ID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Roles",
                        column: x => x.ROL_ID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users",
                        column: x => x.USR_ID,
                        principalTable: "Users",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DietTemplateDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TEM_ID = table.Column<int>(type: "integer", nullable: false),
                    TED_Day = table.Column<int>(type: "integer", nullable: false),
                    MEA_ID = table.Column<int>(type: "integer", nullable: false),
                    TED_PercKCal = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietTemplateDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DietTemplateDetails_DietTemplates",
                        column: x => x.TEM_ID,
                        principalTable: "DietTemplates",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DietDailyMeals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DIE_ID = table.Column<int>(type: "integer", nullable: false),
                    DME_Day = table.Column<int>(type: "integer", nullable: false),
                    MEA_ID = table.Column<int>(type: "integer", nullable: false),
                    DME_Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietDailyMeals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DietDailyMeals_Diets",
                        column: x => x.DIE_ID,
                        principalTable: "Diets",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DietDailyMeals_Meals",
                        column: x => x.MEA_ID,
                        principalTable: "Meals",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DietDailyDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DME_ID = table.Column<int>(type: "integer", nullable: false),
                    ALI_ID = table.Column<int>(type: "integer", nullable: false),
                    DDE_Qty = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietDailyDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DietDailyDetails_Aliments",
                        column: x => x.ALI_ID,
                        principalTable: "Aliments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DietDailyDetails_DietDailyMeals",
                        column: x => x.DME_ID,
                        principalTable: "DietDailyMeals",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aliments_CAT_ID",
                table: "Aliments",
                column: "CAT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Aliments_LIB_ID",
                table: "Aliments",
                column: "LIB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LIB_ID",
                table: "Categories",
                column: "LIB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Checkups_USR_ID",
                table: "Checkups",
                column: "USR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DietDailyDetails_ALI_ID",
                table: "DietDailyDetails",
                column: "ALI_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DietDailyDetails_DME_ID",
                table: "DietDailyDetails",
                column: "DME_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DietDailyMeals_DIE_ID",
                table: "DietDailyMeals",
                column: "DIE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DietDailyMeals_MEA_ID",
                table: "DietDailyMeals",
                column: "MEA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_TEN_ID",
                table: "Diets",
                column: "TEN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Diets_USR_ID",
                table: "Diets",
                column: "USR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DietTemplateDetails_TEM_ID",
                table: "DietTemplateDetails",
                column: "TEM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DietTemplates_TEN_ID",
                table: "DietTemplates",
                column: "TEN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodIntollerances_USR_ID",
                table: "FoodIntollerances",
                column: "USR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedStrings",
                table: "LocalizedStrings",
                columns: new[] { "LAN_ID", "RES_Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedTables_LAN_ID",
                table: "LocalizedTables",
                column: "LAN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_TEN_ID",
                table: "Meals",
                column: "TEN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RolesClaims_ROL_ID",
                table: "RolesClaims",
                column: "ROL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_LIB_ID",
                table: "Tenants",
                column: "LIB_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LAN_ID",
                table: "Users",
                column: "LAN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TEN_ID",
                table: "Users",
                column: "TEN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_ROL_ID",
                table: "UsersRoles",
                column: "ROL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_USR_ID",
                table: "UsersRoles",
                column: "USR_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkups");

            migrationBuilder.DropTable(
                name: "DietDailyDetails");

            migrationBuilder.DropTable(
                name: "DietTemplateDetails");

            migrationBuilder.DropTable(
                name: "FoodIntollerances");

            migrationBuilder.DropTable(
                name: "LAFParameters");

            migrationBuilder.DropTable(
                name: "LocalizedStrings");

            migrationBuilder.DropTable(
                name: "LocalizedTables");

            migrationBuilder.DropTable(
                name: "RolesClaims");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Aliments");

            migrationBuilder.DropTable(
                name: "DietDailyMeals");

            migrationBuilder.DropTable(
                name: "DietTemplates");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Diets");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Libraries");
        }
    }
}
