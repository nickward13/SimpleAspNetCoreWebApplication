using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleAspNetCoreWebApplication.Pages
{
    public class AboutModel : PageModel
    {
        [BindProperty]
        public string CurrentOperatingSystem { get; set; }
        [BindProperty]
        public string CurrentIpAddress { get; set; }
        [BindProperty]
        public string CurrentHostName { get; set; }

        public void OnGet()
        {
            CurrentOperatingSystem = Environment.OSVersion.VersionString;
            CurrentHostName = System.Net.Dns.GetHostName();
            CurrentIpAddress = System.Net.Dns.GetHostAddresses(CurrentHostName)[0].ToString();
        }
    }
}