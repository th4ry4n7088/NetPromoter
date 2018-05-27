using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NetPromoter.Web.Models;

namespace NetPromoter.Web.Controllers
{
    public class PageRatingsController : ApiController
    {
        private RatingContext db = new RatingContext();

        // GET: api/PageRatings
        public IQueryable<PageRating> GetPageRatings()
        {
            return db.PageRatings;
        }

        // GET: api/PageRatings/5
        [ResponseType(typeof(PageRating))]
        public async Task<IHttpActionResult> GetPageRating(int id)
        {
            PageRating pageRating = await db.PageRatings.FindAsync(id);
            if (pageRating == null)
            {
                return NotFound();
            }

            return Ok(pageRating);
        }

        // PUT: api/PageRatings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPageRating(int id, PageRating pageRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pageRating.Id)
            {
                return BadRequest();
            }

            db.Entry(pageRating).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageRatingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PageRatings
        [ResponseType(typeof(PageRating))]
        public async Task<IHttpActionResult> PostPageRating(PageRating pageRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PageRatings.Add(pageRating);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pageRating.Id }, pageRating);
        }

        // DELETE: api/PageRatings/5
        [ResponseType(typeof(PageRating))]
        public async Task<IHttpActionResult> DeletePageRating(int id)
        {
            PageRating pageRating = await db.PageRatings.FindAsync(id);
            if (pageRating == null)
            {
                return NotFound();
            }

            db.PageRatings.Remove(pageRating);
            await db.SaveChangesAsync();

            return Ok(pageRating);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PageRatingExists(int id)
        {
            return db.PageRatings.Count(e => e.Id == id) > 0;
        }
    }
}