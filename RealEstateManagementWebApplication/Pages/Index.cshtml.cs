using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RealEstateManagementLibrary.Models;
using RealEstateManagementLibrary.Models.RealEstate;
using RealEstateManagementLibrary.Utils.Management;

namespace RealEstateManagementWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<RealEstate> RealEstates { get; private set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            LoadList();
        }

        private void LoadList()
        {
            var realEstateManagement = new RealEstateManagementImpl(@"");
            RealEstates = realEstateManagement.GetAll().ToList();
        }

        public void LoadListAction(MouseEventArgs e)
        {
            Console.WriteLine("test");
            LoadList();
        }
    }
}