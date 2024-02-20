using Microsoft.AspNetCore.Mvc;
using WS.Web.Interfaces;

namespace WS.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarningSentenceController : ControllerBase
{
    private readonly IWarningSentenceViewModelService _warningSentenceViewModelService;

    public WarningSentenceController(IWarningSentenceViewModelService warningSentenceViewModelService)
    {
        _warningSentenceViewModelService = warningSentenceViewModelService;
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAllWarningSentences()
    {
        var warningSentences = await _warningSentenceViewModelService.GetWarningSentenceViewModelsAsync();
        return Ok(warningSentences);
    }
}