using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using VolkDiet.Core.dbcontext;
namespace VolkDiet.Core.EF
{
    public partial class volkdietContext : VDDbContext
    {
        // hack for multiple type of db providers
        protected readonly IConfiguration Configuration;

        protected volkdietContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //--
        public volkdietContext()
        {
        }

        public volkdietContext(DbContextOptions<volkdietContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aliment> Aliments { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Checkup> Checkups { get; set; } = null!;
        public virtual DbSet<Diet> Diets { get; set; } = null!;
        public virtual DbSet<DietDailyDetail> DietDailyDetails { get; set; } = null!;
        public virtual DbSet<DietDailyMeal> DietDailyMeals { get; set; } = null!;
        public virtual DbSet<DietTemplate> DietTemplates { get; set; } = null!;
        public virtual DbSet<DietTemplateDetail> DietTemplateDetails { get; set; } = null!;
        public virtual DbSet<FoodIntollerance> FoodIntollerances { get; set; } = null!;
        public virtual DbSet<Lafparameter> Lafparameters { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<Library> Libraries { get; set; } = null!;
        public virtual DbSet<LocalizedString> LocalizedStrings { get; set; } = null!;
        public virtual DbSet<LocalizedTable> LocalizedTables { get; set; } = null!;
        public virtual DbSet<Meal> Meals { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RolesClaim> RolesClaims { get; set; } = null!;
        public virtual DbSet<Tenant> Tenants { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UsersRole> UsersRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=xxx;database=xxx;trusted_connection=true;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aliment>(entity =>
            {
                //entity.Property(e => e.Id).HasColumnName("ID");
                entity.HasIdentityIdColumn();//

                entity.Property(e => e.AliAlcool).HasColumnName("ALI_Alcool");

                entity.Property(e => e.AliAmono).HasColumnName("ALI_AMono");

                entity.Property(e => e.AliApoly).HasColumnName("ALI_APoly");

                entity.Property(e => e.AliAsatur).HasColumnName("ALI_ASatur");

                entity.Property(e => e.AliCalcium).HasColumnName("ALI_Calcium");

                entity.Property(e => e.AliChlorine).HasColumnName("ALI_Chlorine");

                entity.Property(e => e.AliCholeterol).HasColumnName("ALI_Choleterol");

                entity.Property(e => e.AliCopper).HasColumnName("ALI_Copper");

                entity.Property(e => e.AliDesc)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ALI_Desc");

                entity.Property(e => e.AliFibelSol).HasColumnName("ALI_FibelSol");

                entity.Property(e => e.AliFiber).HasColumnName("ALI_Fiber");

                entity.Property(e => e.AliFructose).HasColumnName("ALI_Fructose");

                entity.Property(e => e.AliGalactose).HasColumnName("ALI_Galactose");

                entity.Property(e => e.AliGlucides).HasColumnName("ALI_Glucides");

                entity.Property(e => e.AliGlucose).HasColumnName("ALI_Glucose");

                entity.Property(e => e.AliIron).HasColumnName("ALI_Iron");

                entity.Property(e => e.AliIudium).HasColumnName("ALI_Iudium");

                entity.Property(e => e.AliK)
                    .HasColumnName("ALI_K")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.AliKcal).HasColumnName("ALI_KCal");

                entity.Property(e => e.AliLactose).HasColumnName("ALI_Lactose");

                entity.Property(e => e.AliLastMod)
                    .HasColumnType("datetime")
                    .HasColumnName("ALI_LastMod");

                entity.Property(e => e.AliLipids).HasColumnName("ALI_Lipids");

                entity.Property(e => e.AliMagnesium).HasColumnName("ALI_Magnesium");

                entity.Property(e => e.AliMaltose).HasColumnName("ALI_Maltose");

                entity.Property(e => e.AliNiacinaB3).HasColumnName("ALI_NiacinaB3");

                entity.Property(e => e.AliPhosphorus).HasColumnName("ALI_Phosphorus");

                entity.Property(e => e.AliPotassium).HasColumnName("ALI_Potassium");

                entity.Property(e => e.AliProtein).HasColumnName("ALI_Protein");

                entity.Property(e => e.AliRiboflavinaB2).HasColumnName("ALI_RiboflavinaB2");

                entity.Property(e => e.AliSelenium).HasColumnName("ALI_Selenium");

                entity.Property(e => e.AliSodium).HasColumnName("ALI_Sodium");

                entity.Property(e => e.AliStarch).HasColumnName("ALI_Starch");

                entity.Property(e => e.AliSucrose).HasColumnName("ALI_Sucrose");

                entity.Property(e => e.AliTiaminaB1).HasColumnName("ALI_TiaminaB1");

                entity.Property(e => e.AliVitAreteq).HasColumnName("ALI_VitAReteq");

                entity.Property(e => e.AliVitB12).HasColumnName("ALI_VitB12");

                entity.Property(e => e.AliVitB6).HasColumnName("ALI_VitB6");

                entity.Property(e => e.AliVitC).HasColumnName("ALI_VitC");

                entity.Property(e => e.AliVitE).HasColumnName("ALI_VitE");

                entity.Property(e => e.AliVitEreteq).HasColumnName("ALI_VitEReteq");

                entity.Property(e => e.AliWater).HasColumnName("ALI_Water");

                entity.Property(e => e.AliZinc).HasColumnName("ALI_Zinc");

                entity.Property(e => e.CatId).HasColumnName("CAT_ID");

                entity.Property(e => e.LibId).HasColumnName("LIB_ID");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Aliments)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_Aliments_Categories");

                entity.HasOne(d => d.Lib)
                    .WithMany(p => p.Aliments)
                    .HasForeignKey(d => d.LibId)
                    .HasConstraintName("FK_Aliments_Libraries");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIdentityIdColumn(); 

                entity.Property(e => e.CatDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CAT_Desc");

                entity.Property(e => e.LibId).HasColumnName("LIB_ID");

                entity.HasOne(d => d.Lib)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.LibId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Categories_Libraries");
            });

            modelBuilder.Entity<Checkup>(entity =>
            {
                entity.HasIdentityIdColumn();

                entity.Property(e => e.CupDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CUP_Date");

                entity.Property(e => e.CupFatMass).HasColumnName("CUP_FatMass");

                entity.Property(e => e.CupHeigth).HasColumnName("CUP_Heigth");

                entity.Property(e => e.CupLeanMass).HasColumnName("CUP_LeanMass");

                entity.Property(e => e.CupMis1).HasColumnName("CUP_Mis1");

                entity.Property(e => e.CupMis2).HasColumnName("CUP_Mis2");

                entity.Property(e => e.CupMis3).HasColumnName("CUP_Mis3");

                entity.Property(e => e.CupMis4).HasColumnName("CUP_Mis4");

                entity.Property(e => e.CupWeight).HasColumnName("CUP_Weight");

                entity.Property(e => e.UsrId).HasColumnName("USR_ID");

                entity.HasOne(d => d.Usr)
                    .WithMany(p => p.Checkups)
                    .HasForeignKey(d => d.UsrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Checkups_Users");
            });

            modelBuilder.Entity<Diet>(entity =>
            {
                entity.HasIdentityIdColumn();

                entity.Property(e => e.DieDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DIE_Desc");

                entity.Property(e => e.DieLastMod)
                    .HasColumnType("datetime")
                    .HasColumnName("DIE_LastMod");

                entity.Property(e => e.DieNote)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DIE_Note");

                entity.Property(e => e.DiePerCarbs).HasColumnName("DIE_PerCarbs");

                entity.Property(e => e.DiePerFats).HasColumnName("DIE_PerFats");

                entity.Property(e => e.DiePerProts).HasColumnName("DIE_PerProts");

                entity.Property(e => e.DieRequirement).HasColumnName("DIE_Requirement");

                entity.Property(e => e.TenId).HasColumnName("TEN_ID");

                entity.Property(e => e.UsrId).HasColumnName("USR_ID");

                entity.HasOne(d => d.Ten)
                    .WithMany(p => p.Diets)
                    .HasForeignKey(d => d.TenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diets_Tenants");

                entity.HasOne(d => d.Usr)
                    .WithMany(p => p.Diets)
                    .HasForeignKey(d => d.UsrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diets_Users");
            });

            modelBuilder.Entity<DietDailyDetail>(entity =>
            {
                entity.HasIdentityIdColumn();

                entity.Property(e => e.AliId).HasColumnName("ALI_ID");

                entity.Property(e => e.DdeQty).HasColumnName("DDE_Qty");

                entity.Property(e => e.DmeId).HasColumnName("DME_ID");

                entity.HasOne(d => d.Ali)
                    .WithMany(p => p.DietDailyDetails)
                    .HasForeignKey(d => d.AliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DietDailyDetails_Aliments");

                entity.HasOne(d => d.Dme)
                    .WithMany(p => p.DietDailyDetails)
                    .HasForeignKey(d => d.DmeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DietDailyDetails_DietDailyMeals");
            });

            modelBuilder.Entity<DietDailyMeal>(entity =>
            {
                entity.HasIdentityIdColumn();

                entity.Property(e => e.DieId).HasColumnName("DIE_ID");

                entity.Property(e => e.DmeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DME_Date");

                entity.Property(e => e.DmeDay).HasColumnName("DME_Day");

                entity.Property(e => e.MeaId).HasColumnName("MEA_ID");

                entity.HasOne(d => d.Die)
                    .WithMany(p => p.DietDailyMeals)
                    .HasForeignKey(d => d.DieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DietDailyMeals_Diets");

                entity.HasOne(d => d.Mea)
                    .WithMany(p => p.DietDailyMeals)
                    .HasForeignKey(d => d.MeaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DietDailyMeals_Meals");
            });

            modelBuilder.Entity<DietTemplate>(entity =>
            {
                entity.HasIdentityIdColumn();

                entity.Property(e => e.TemDesc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TEM_Desc");

                entity.Property(e => e.TemPercCarbs).HasColumnName("TEM_PercCarbs");

                entity.Property(e => e.TemPercFats).HasColumnName("TEM_PercFats");

                entity.Property(e => e.TemPercProts).HasColumnName("TEM_PercProts");

                entity.Property(e => e.TenId).HasColumnName("TEN_ID");

                entity.HasOne(d => d.Ten)
                    .WithMany(p => p.DietTemplates)
                    .HasForeignKey(d => d.TenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DietTemplates_Meals");
            });

            modelBuilder.Entity<DietTemplateDetail>(entity =>
            {
                entity.HasIdentityIdColumn();

                entity.Property(e => e.MeaId).HasColumnName("MEA_ID");

                entity.Property(e => e.TedDay).HasColumnName("TED_Day");

                entity.Property(e => e.TedPercKcal).HasColumnName("TED_PercKCal");

                entity.Property(e => e.TemId).HasColumnName("TEM_ID");

                entity.HasOne(d => d.Tem)
                    .WithMany(p => p.DietTemplateDetails)
                    .HasForeignKey(d => d.TemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DietTemplateDetails_DietTemplates");
            });

            modelBuilder.Entity<FoodIntollerance>(entity =>
            {
                entity.HasIdentityIdColumn();

                entity.Property(e => e.FinDesc)
                    .IsUnicode(false)
                    .HasColumnName("FIN_Desc");

                entity.Property(e => e.FinSeverity).HasColumnName("FIN_Severity");

                entity.Property(e => e.UsrId).HasColumnName("USR_ID");

                entity.HasOne(d => d.Usr)
                    .WithMany(p => p.FoodIntollerances)
                    .HasForeignKey(d => d.UsrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FoodIntollerances_Users");
            });

            modelBuilder.Entity<Lafparameter>(entity =>
            {
                entity.ToTable("LAFParameters");

                entity.HasIdentityIdColumn();

                entity.Property(e => e.LafAgeMax).HasColumnName("LAF_AgeMax");

                entity.Property(e => e.LafAgeMin).HasColumnName("LAF_AgeMin");

                entity.Property(e => e.LafAlg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LAF_Alg");

                entity.Property(e => e.LafLvl).HasColumnName("LAF_Lvl");

                entity.Property(e => e.LafSex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("LAF_Sex");

                entity.Property(e => e.LafValue).HasColumnName("LAF_Value");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasIdentityIdColumn();

                entity.Property(e => e.LanCulture)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAN_Culture");

                entity.Property(e => e.LanDisplayOrder).HasColumnName("LAN_DisplayOrder");

                entity.Property(e => e.LanImageName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LAN_ImageName");

                entity.Property(e => e.LanName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAN_Name");
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity.HasIdentityIdColumn();

                entity.Property(e => e.LibDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LIB_Desc");
            });

            modelBuilder.Entity<LocalizedString>(entity =>
            {
                entity.HasIndex(e => new { e.LanId, e.ResName }, "IX_LocalizedStrings")
                    .IsUnique();

                entity.HasIdentityIdColumn();

                entity.Property(e => e.LanId).HasColumnName("LAN_ID");

                entity.Property(e => e.ResName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("RES_Name");

                entity.Property(e => e.ResValue)
                    .IsUnicode(false)
                    .HasColumnName("RES_Value");

                entity.HasOne(d => d.Lan)
                    .WithMany(p => p.LocalizedStrings)
                    .HasForeignKey(d => d.LanId)
                    .HasConstraintName("FK_LocalizedStrings_Languages");
            });

            modelBuilder.Entity<LocalizedTable>(entity =>
            {
                entity.HasIdentityIdColumn();

                entity.Property(e => e.LanId).HasColumnName("LAN_ID");

                entity.Property(e => e.LtbProperty)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LTB_Property");

                entity.Property(e => e.LtbRecordId).HasColumnName("LTB_RecordID");

                entity.Property(e => e.LtbTable)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LTB_Table");

                entity.Property(e => e.LtbValue)
                    .IsUnicode(false)
                    .HasColumnName("LTB_Value");

                entity.HasOne(d => d.Lan)
                    .WithMany(p => p.LocalizedTables)
                    .HasForeignKey(d => d.LanId)
                    .HasConstraintName("FK_LocalizedTables_Languages");
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.HasIdentityIdColumn();

                entity.Property(e => e.MeaDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MEA_Desc");

                entity.Property(e => e.TenId).HasColumnName("TEN_ID");

                entity.HasOne(d => d.Ten)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.TenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Meals_Tenants1");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIdentityIdColumn();

                entity.Property(e => e.RolDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROL_Desc");
            });

            modelBuilder.Entity<RolesClaim>(entity =>
            {
                entity.HasIdentityIdColumn();

                entity.Property(e => e.RclName)
                    .IsUnicode(false)
                    .HasColumnName("RCL_Name");

                entity.Property(e => e.RclValue)
                    .IsUnicode(false)
                    .HasColumnName("RCL_Value");

                entity.Property(e => e.RolId).HasColumnName("ROL_ID");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.RolesClaims)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_RolesClaims_Roles");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.HasIdentityIdColumn();

                entity.Property(e => e.LibId).HasColumnName("LIB_ID");

                entity.Property(e => e.TenDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TEN_Desc");

                entity.Property(e => e.TenIsTemplate).HasColumnName("TEN_IsTemplate");

                entity.HasOne(d => d.Lib)
                    .WithMany(p => p.Tenants)
                    .HasForeignKey(d => d.LibId)
                    .HasConstraintName("FK_Tenants_Libraries");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIdentityIdColumn();

                // entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
                entity.HasSoftwareDeletion();//

                entity.Property(e => e.LanId).HasColumnName("LAN_ID");

                entity.Property(e => e.TenId).HasColumnName("TEN_ID");

                entity.Property(e => e.UsrDtReg)
                    .HasColumnType("datetime")
                    .HasColumnName("USR_DtReg");

                entity.Property(e => e.UsrEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USR_Email");

                entity.Property(e => e.UsrLogin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USR_Login");

                entity.Property(e => e.UsrPwdHash)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USR_PwdHash");

                entity.Property(e => e.UsrStep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USR_Step");

                entity.HasOne(d => d.Lan)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LanId)
                    .HasConstraintName("FK_Users_Languages");

                entity.HasOne(d => d.Ten)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Tenants");
            });

            modelBuilder.Entity<UsersRole>(entity =>
            {
                entity.HasIdentityIdColumn();

                entity.Property(e => e.RolId).HasColumnName("ROL_ID");

                entity.Property(e => e.UsrId).HasColumnName("USR_ID");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK_UsersRoles_Roles");

                entity.HasOne(d => d.Usr)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.UsrId)
                    .HasConstraintName("FK_UsersRoles_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
