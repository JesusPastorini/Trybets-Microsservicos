using System;
using Microsoft.AspNetCore.Mvc;
using TryBets.Matches.Repository;



namespace TryBets.Matches.Controllers;

[Route("[controller]")]
public class TeamController : Controller
{
    private readonly ITeamRepository _repository;
    public TeamController(ITeamRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_repository.Get());
    }
}