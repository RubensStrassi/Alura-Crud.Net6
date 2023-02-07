﻿using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController: ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public IActionResult AdcionaFilme([FromBody]Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(RecupearFilmePorId), new {id = filme.Id}, filme);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilme([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecupearFilmePorId(int id)
    {
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }
}
