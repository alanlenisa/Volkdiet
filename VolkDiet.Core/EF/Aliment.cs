using System;
using System.Collections.Generic;

namespace VolkDiet.Core.EF
{
    public partial class Aliment:dbcontext.VDEntity
    {
        public Aliment()
        {
            DietDailyDetails = new HashSet<DietDailyDetail>();
        }

       // public int Id { get; set; }
        public string? AliDesc { get; set; }
        public int? LibId { get; set; }
        public int? CatId { get; set; }
        public double? AliK { get; set; }
        public DateTime? AliLastMod { get; set; }
        public double? AliKcal { get; set; }
        public double? AliProtein { get; set; }
        public double? AliLipids { get; set; }
        public double? AliCholeterol { get; set; }
        public double? AliGlucides { get; set; }
        public double? AliStarch { get; set; }
        public double? AliFiber { get; set; }
        public double? AliFibelSol { get; set; }
        public double? AliAlcool { get; set; }
        public double? AliWater { get; set; }
        public double? AliIron { get; set; }
        public double? AliCalcium { get; set; }
        public double? AliSodium { get; set; }
        public double? AliPotassium { get; set; }
        public double? AliPhosphorus { get; set; }
        public double? AliZinc { get; set; }
        public double? AliMagnesium { get; set; }
        public double? AliCopper { get; set; }
        public double? AliSelenium { get; set; }
        public double? AliChlorine { get; set; }
        public double? AliIudium { get; set; }
        public double? AliTiaminaB1 { get; set; }
        public double? AliRiboflavinaB2 { get; set; }
        public double? AliVitC { get; set; }
        public double? AliNiacinaB3 { get; set; }
        public double? AliVitB6 { get; set; }
        public double? AliVitB12 { get; set; }
        public double? AliVitAreteq { get; set; }
        public double? AliVitEreteq { get; set; }
        public double? AliVitE { get; set; }
        public double? AliAsatur { get; set; }
        public double? AliApoly { get; set; }
        public double? AliAmono { get; set; }
        public double? AliGlucose { get; set; }
        public double? AliFructose { get; set; }
        public double? AliGalactose { get; set; }
        public double? AliSucrose { get; set; }
        public double? AliMaltose { get; set; }
        public double? AliLactose { get; set; }

        public virtual Category? Cat { get; set; }
        public virtual Library? Lib { get; set; }
        public virtual ICollection<DietDailyDetail> DietDailyDetails { get; set; }
    }
}
