using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicMerge.Data;

namespace MusicMerge
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneratedImagesController : ControllerBase
    {
        private readonly MusicMergeContext _context;

        public GeneratedImagesController(MusicMergeContext context)
        {
            _context = context;
        }

        // GET: api/GeneratedImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneratedImage>>> GetGeneratedImage()
        {
          if (_context.GeneratedImage == null)
          {
              return NotFound();
          }
            return await _context.GeneratedImage.ToListAsync();
        }

        // GET: api/GeneratedImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneratedImage>> GetGeneratedImage(int id)
        {
          if (_context.GeneratedImage == null)
          {
              return NotFound();
          }
            var generatedImage = await _context.GeneratedImage.FindAsync(id);

            if (generatedImage == null)
            {
                return NotFound();
            }

            return generatedImage;
        }

        // PUT: api/GeneratedImages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneratedImage(int id, GeneratedImage generatedImage)
        {
            if (id != generatedImage.GeneratedImageId)
            {
                return BadRequest();
            }

            _context.Entry(generatedImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneratedImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GeneratedImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeneratedImage>> PostGeneratedImage(GeneratedImage generatedImage)
        {
          if (_context.GeneratedImage == null)
          {
              return Problem("Entity set 'MusicMergeContext.GeneratedImage'  is null.");
          }
            _context.GeneratedImage.Add(generatedImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneratedImage", new { id = generatedImage.GeneratedImageId }, generatedImage);
        }

        // DELETE: api/GeneratedImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneratedImage(int id)
        {
            if (_context.GeneratedImage == null)
            {
                return NotFound();
            }
            var generatedImage = await _context.GeneratedImage.FindAsync(id);
            if (generatedImage == null)
            {
                return NotFound();
            }

            _context.GeneratedImage.Remove(generatedImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeneratedImageExists(int id)
        {
            return (_context.GeneratedImage?.Any(e => e.GeneratedImageId == id)).GetValueOrDefault();
        }
    }
}
