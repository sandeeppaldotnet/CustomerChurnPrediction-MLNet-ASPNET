using ChurnPredictionTrainer.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ChurnController : ControllerBase
{
    private readonly PredictionService _predictionService;

    public ChurnController(PredictionService predictionService)
    {
        _predictionService = predictionService;
    }

    [HttpPost]
    public IActionResult Predict([FromBody] CustomerData input)
    {
        var prediction = _predictionService.Predict(input);
        return Ok(prediction);
    }
}
