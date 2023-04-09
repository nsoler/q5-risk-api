using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using q5_risk_api.Interfaces;
using q5_risk_api.Models;
using q5_risk_api.Interfaces;
using q5_risk_api.Services;

namespace q5_risk_api.Controllers;

[ApiController]
[Route("[controller]")]

public class EvaluateController : ControllerBase
{
    private readonly ILogger<EvaluateController> _logger;
    private readonly IExternalService _externalService;

    public EvaluateController(ILogger<EvaluateController> logger, IExternalService externalService)
    {
        _logger = logger;
        _externalService = externalService;
    }

    [HttpGet(Name = "Person")]
    public async Task<EvaluatationResultModel> Get()
    {
        return new EvaluatationResultModel();
    }
    
}
