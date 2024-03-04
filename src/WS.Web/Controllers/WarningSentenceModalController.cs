using Microsoft.AspNetCore.Mvc;
using WS.Web.Interfaces;

namespace WS.Web.Controllers;

[Route("api/WarningSentence/modal")]
[ApiController]
public class WarningSentenceModalController : ControllerBase
{
    private readonly IWarningSentenceModalService _warningSentenceModalService;

    public WarningSentenceModalController(IWarningSentenceModalService warningSentenceModalService)
    {
        _warningSentenceModalService = warningSentenceModalService;
    }
    
    [HttpGet("rename/{id}")]
    public async Task<IActionResult> GetRenameModalContent(int id)
    {
        var warningSentence = await _warningSentenceModalService.GetWarningSentenceModalAsync(id);
        return Ok(warningSentence);
    }
}