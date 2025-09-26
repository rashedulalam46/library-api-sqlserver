using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    // Dummy in-memory data store
    private static readonly List<Author> Authors = new List<Author>
    {
        new Author { Id = 1, Name = "Jane Austen" },
        new Author { Id = 2, Name = "Mark Twain" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Author>> GetAll()
    {
        return Ok(Authors);
    }

    [HttpGet("{id}")]
    public ActionResult<Author> GetById(int id)
    {
        var author = Authors.Find(a => a.Id == id);
        if (author == null)
            return NotFound();
        return Ok(author);
    }

    [HttpPost]
    public ActionResult<Author> Create(Author author)
    {
        author.Id = Authors.Count + 1;
        Authors.Add(author);
        return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Author updatedAuthor)
    {
        var author = Authors.Find(a => a.Id == id);
        if (author == null)
            return NotFound();

        author.Name = updatedAuthor.Name;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var author = Authors.Find(a => a.Id == id);
        if (author == null)
            return NotFound();

        Authors.Remove(author);
        return NoContent();
    }
}

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
}