using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQTAssignment;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int Age { get; set; }

        [BindProperty]
        public string Location { get; set; }

        public double Premium { get; set; }

        public void OnPost()
        {
            // Call InsuranceService to calculate premium
            InsuranceService insuranceService = new InsuranceService();
            Premium = insuranceService.CalculatePremium(Age, Location);
        }
    }
}
