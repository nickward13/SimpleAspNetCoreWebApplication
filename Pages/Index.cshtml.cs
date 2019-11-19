using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimpleAspNetCoreWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string CurrentOperatingSystem { get; set; }
        [BindProperty]
        public string CurrentHostName { get; set; }
        [BindProperty]
        public IPAddress[] CurrentIpAddresses { get; set; }
        public void OnGet()
        {
            CurrentOperatingSystem = Environment.OSVersion.VersionString;
            CurrentHostName = System.Net.Dns.GetHostName();
            CurrentIpAddresses = System.Net.Dns.GetHostAddresses(CurrentHostName);
        }
    }
}
