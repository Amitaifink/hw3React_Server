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
    public class RecipesController : ApiController
    {
        GroupAmitaiEntities db = new GroupAmitaiEntities();
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            List<Recipe> recipes = db.Recipes.ToList();
            List<RecipesDto> recipesDtos = new List<RecipesDto>();
            try
            {
                foreach (Recipe r in recipes)
                {
                    RecipesDto rDto = new RecipesDto();
                    rDto.recipeId = Convert.ToInt32(r.recipesId);
                    rDto.recipeName = r.recipesName;
                    rDto.imgUrl = r.imageUrl;
                    rDto.cookingMethod = r.cookingMethod;
                    rDto.ingredients = new List<IngredientsDto>();
                    rDto.time = Convert.ToInt32(r.time);
                    foreach (Ingredient i in r.Ingredients)
                    {
                        IngredientsDto iDtor = new IngredientsDto();
                        iDtor.ingredientId = Convert.ToInt32(i.ingredientsId);
                        iDtor.ingredientName = i.ingredientName;
                        iDtor.calories = Convert.ToInt32(i.calories);
                        iDtor.imgUrl = i.imgUrl;
                        rDto.ingredients.Add(iDtor);
                    }
                    recipesDtos.Add(rDto);
                }
                return Ok(recipesDtos);
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
        public IHttpActionResult Post([FromBody] RecipesDto value)
        {
            try
            {
                RecipesDto i = value;
                Recipe x = new Recipe();
                x.recipesName = i.recipeName;
                x.imageUrl = i.imgUrl;
                x.time = i.time;
                x.cookingMethod = i.cookingMethod;
                List<Ingredient> ing = new List<Ingredient>();
                foreach (IngredientsDto item in i.ingredients)
                {
                    ing.Add(db.Ingredients.FirstOrDefault(y => y.ingredientsId == item.ingredientId));
                }
                x.Ingredients = ing;
                db.Recipes.Add(x);                
                db.SaveChanges();
                return Ok();
                // return Created(new Uri(Request.RequestUri.AbsoluteUri + i.recipeId), i);
            }   
            catch (Exception ex)
            {
                return (BadRequest(ex.Message));
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