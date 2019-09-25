using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FoodProject;

namespace FoodProject.Controllers
{
    public class FoodsController : ApiController
    {
        private FoodDBEntities db = new FoodDBEntities();

        // GET: api/Foods
        public List<Food> GetFoods()
        {
            return db.Foods.ToList();
        }

        // GET: api/Foods/5
        [ResponseType(typeof(Food))]
        public IHttpActionResult GetFood(int id)
        {
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        // PUT: api/Foods/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFood(int id, Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != food.ID)
            {
                return BadRequest();
            }

            db.Entry(food).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(id))
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

        // POST: api/Foods
        [ResponseType(typeof(Food))]
        public IHttpActionResult PostFood(Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Foods.Add(food);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = food.ID }, food);
        }

        // DELETE: api/Foods/5
        [ResponseType(typeof(Food))]
        public IHttpActionResult DeleteFood(int id)
        {
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return NotFound();
            }

            db.Foods.Remove(food);
            db.SaveChanges();

            return Ok(food);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FoodExists(int id)
        {
            return db.Foods.Count(e => e.ID == id) > 0;
        }

        [Route("api/foods/byname/{name}")]
        [HttpGet]
        public IEnumerable<Food> GetBySenderName([FromUri] string name)
        {
            IEnumerable<Food> result = db.Foods.Where(m => m.Name.ToUpper().Contains(name.ToUpper()));
            return result;
        }

        [Route("api/foods/mincal/{cal}")]
        [HttpGet]
        public IEnumerable<Food> GetBySenderMinimumCalories([FromUri] int cal)
        {
            IEnumerable<Food> result = db.Foods.Where(m => m.Calories >= cal);
            return result;
        }

        [Route("api/messages/search")]
        [HttpGet]
        public IEnumerable<Food> GetByFilter(string name = "", int grade = 0, int mincalories = 0, int maxcalories = int.MaxValue)
        {
            return db.Foods.Where(f => f.Name.ToUpper().Contains(name.ToUpper()) &&
            f.Grade > grade &&
            f.Calories > mincalories &&
            f.Calories < maxcalories);
        }
    }
}
