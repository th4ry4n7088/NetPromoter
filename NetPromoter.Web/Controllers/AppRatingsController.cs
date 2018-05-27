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
    public class AppRatingsController : ApiController
    {
        private RatingContext db = new RatingContext();

        // GET: api/AppRatings
        public IQueryable<AppRating> GetAppRatings()
        {
            return db.AppRatings;
        }

        [Route("api/AppRatings/UserRatings")]
        [ResponseType(typeof(int))]
        public async Task<IHttpActionResult> GetAppUserRatings()
        {
            var userRatings = await db.AppRatings.AverageAsync(r => r.Rating);
            return Ok(Convert.ToInt32(userRatings));
        }

        // GET: api/AppRatings/5
        [ResponseType(typeof(AppRating))]
        public async Task<IHttpActionResult> GetAppRating(int id)
        {
            AppRating appRating = await db.AppRatings.FindAsync(id);
            if (appRating == null)
            {
                return NotFound();
            }

            return Ok(appRating);
        }

        // PUT: api/AppRatings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAppRating(int id, AppRating appRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appRating.Id)
            {
                return BadRequest();
            }

            db.Entry(appRating).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppRatingExists(id))
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

        // POST: api/AppRatings
        [ResponseType(typeof(AppRating))]
        public async Task<IHttpActionResult> PostAppRating(AppRating appRating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AppRatings.Add(appRating);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = appRating.Id }, appRating);
        }

        // DELETE: api/AppRatings/5
        [ResponseType(typeof(AppRating))]
        public async Task<IHttpActionResult> DeleteAppRating(int id)
        {
            AppRating appRating = await db.AppRatings.FindAsync(id);
            if (appRating == null)
            {
                return NotFound();
            }

            db.AppRatings.Remove(appRating);
            await db.SaveChangesAsync();

            return Ok(appRating);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppRatingExists(int id)
        {
            return db.AppRatings.Count(e => e.Id == id) > 0;
        }
    }
}