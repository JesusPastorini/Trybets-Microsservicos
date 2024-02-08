using System;
using Microsoft.AspNetCore.Mvc;
using TryBets.Repository;

namespace TryBets.Controllers;

[Route("[controller]")]
public class MatchController : Controller
{
    private readonly IMatchRepository _repository;
    public MatchController(IMatchRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{MatchFinished}")]
    public IActionResult Get(bool MatchFinished)
    {
        return Ok(_repository.Get(MatchFinished));
    }
}