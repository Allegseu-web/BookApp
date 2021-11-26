using BookApp.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext context;
        public BooksController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Books>>> Get()
        {
            return await context.Books.ToListAsync();
        }
        [HttpGet("{id}",Name ="ObtenerLibro")]
        public async Task<ActionResult<Books>> Get(int id)
        {
            return await context.Books.FirstOrDefaultAsync(b => b.Id == id);
        }
        [HttpPost]
        public async Task<ActionResult>Post(Books Book)
        {
            context.Books.Add(Book);
            await context.SaveChangesAsync();
            return StatusCode(201);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Books Book)
        {
            context.Entry(Book).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return StatusCode(200);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Book = new Books { Id = id};
            context.Remove(Book);
            await context.SaveChangesAsync();
            return StatusCode(200);
        }
    }

}
