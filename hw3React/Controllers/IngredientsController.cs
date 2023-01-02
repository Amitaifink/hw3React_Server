using hw3React.DTO;
using hw3React.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace hw3React.Controllers
{
    public class IngredientsController : ApiController
    {
        GroupAmitaiEntities db = new GroupAmitaiEntities();
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            List<Ingredient> ingredients = db.Ingredients.ToList();
            List<IngredientsDto> ingredientsDto = new List<IngredientsDto>();
            try
            {
                foreach (Ingredient i in ingredients)
                {
                    IngredientsDto iDto = new IngredientsDto();
                    iDto.ingredientId = Convert.ToInt32(i.ingredientsId);
                    iDto.ingredientName = i.ingredientName;
                    iDto.calories = Convert.ToInt32(i.calories);
                    iDto.imgUrl = i.imgUrl;
                    ingredientsDto.Add(iDto);
                }
                return Ok(ingredientsDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] Ingredient value)
        {
            try
            {
                Ingredient i = value;
                db.Ingredients.Add(i);
                db.SaveChanges();
                return Created(new Uri(Request.RequestUri.AbsoluteUri + i.ingredientsId), i);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}