using Microsoft.AspNetCore.Mvc;
using WS.Core.Interfaces.DomainServices;
using WS.Core.Models.Dtos;
using WS.Web.Interfaces;

namespace WS.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarningSentenceController : ControllerBase
{
    private readonly IWarningSentenceViewModelService _warningSentenceViewModelService;
    private readonly IWarningSentenceService _warningSentenceService;

    public WarningSentenceController(IWarningSentenceViewModelService warningSentenceViewModelService, IWarningSentenceService warningSentenceService)
    {
        _warningSentenceViewModelService = warningSentenceViewModelService;
        _warningSentenceService = warningSentenceService;
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAllWarningSentences()
    {
        var warningSentences = await _warningSentenceViewModelService.GetWarningSentenceViewModelsAsync();
        return Ok(warningSentences);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetWarningSentence(int id)
    {
        var warningSentence = await _warningSentenceViewModelService.GetWarningSentenceViewModel(id);
        return Ok(warningSentence);
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddWarningSentence(WarningSentenceDto warningSentenceDto)
    {
        var warningSentence = await _warningSentenceService.AddWarningSentenceAsync(warningSentenceDto);
        return Ok(warningSentence);
    }
    
    [HttpPost("copy/{id}")]
    public async Task<IActionResult> CopyWarningSentence(int id)
    {
        var warningSentence = await _warningSentenceService.CloneWarningSentenceAsync(id);
        return Ok(warningSentence);
    }
    
    [HttpPut("rename/{id}")]
    public async Task<IActionResult> RenameWarningSentence(int id, string newName)
    {
        var warningSentence = await _warningSentenceService.RenameWarningSentenceAsync(id, newName);
        return Ok(warningSentence);
    }
    
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteWarningSentence(int id)
    {
        var result = await _warningSentenceService.DeleteWarningSentenceAsync(id);
        return Ok(result);
    }
}