using hw3React.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hw3React.DTO
{
    public class RecipesDto
    {
        public int recipeId { get; set; }
        public string recipeName { get; set; }
        public string imgUrl { get; set; }
        public string cookingMethod { get; set; }
        public int time { get; set; }
        public List <IngredientsDto> ingredients { get; set; }
    }
}