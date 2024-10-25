using AutoMapper;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QuizTower.IDP;
using QuizTower.IDP.Pages;

namespace QuizTower.IDP.Pages.Diagnostics;

[SecurityHeaders]
[Authorize]
public class RenewAppConfigModel : PageModel
{
    private readonly ConfigurationDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _environment;
    private readonly IMapper _mapper;
    private readonly ILogger<SeedDataWebHookBased> _logger;

    public RenewAppConfigModel(ConfigurationDbContext context, IConfiguration configuration, IWebHostEnvironment environment, IMapper mapper, ILogger<SeedDataWebHookBased> logger)
    {
        _context = context;
        _configuration = configuration;
        _environment = environment;
        _mapper = mapper;
        _logger = logger;
    }

    public string Message { get; private set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        SeedDataWebHookBased.EnsureSeedData(_context, _configuration, _environment, _mapper, _logger);

        Message = "Configuration and database seeded successfully!";
        return Page();
    }
}
