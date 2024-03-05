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
    
    [HttpGet("create")]
    public async Task<IActionResult> GetCreateModalContent()
    {
        var warningSentence = await _warningSentenceModalService.GetCreateFormModalAsync();
        return Ok(warningSentence);
    }
    
    [HttpGet("edit/{id}")]
    public async Task<IActionResult> GetEditModalContent(int id)
    {
        var warningSentence = await _warningSentenceModalService.GetEditFormModalAsync(id);
        return Ok(warningSentence);
    }

    [HttpGet("rename/{id}")]
    public async Task<IActionResult> GetRenameModalContent(int id)
    {
        var warningSentence = await _warningSentenceModalService.GetWarningSentenceModalAsync(id);
        return Ok(warningSentence);
    }
    
    [HttpGet("copy")]
    public async Task<IActionResult> GetCopyModalContent([FromQuery] List<int> ids)
    {
        var warningSentences = await _warningSentenceModalService.GetWarningSentencesModalAsync(ids);
        return Ok(warningSentences);
    }
    
    [HttpGet("delete")]
    public async Task<IActionResult> GetDeleteModalContent([FromQuery] List<int> ids)
    {
        var warningSentence = await _warningSentenceModalService.GetWarningSentencesModalAsync(ids);
        return Ok(warningSentence);
    }
}