using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace JokesWebApp.Views.Jokes
{
    public class ShowSearchForm : PageModel
    {
        private readonly ILogger<ShowSearchForm> _logger;

        public ShowSearchForm(ILogger<ShowSearchForm> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}