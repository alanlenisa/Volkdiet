using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using VolkDiet.Core.Data;

namespace VolkDiet.Models
{
    public class SetupModel
    {
        public SetupModel()
        {
            Providers = new List<SelectListItem>();
        }
        public string? newurl { get; set; }
        public string server { get; set; }
        public string database { get; set; }
        public string? user { get; set; }
        public string? password { get; set; }
        public bool trusted { get; set; }


        public ProviderType provider { get; set; }
        /// <summary>
        /// list of providers
        /// </summary>
        public List<SelectListItem> Providers { get; set; }

    }
}
