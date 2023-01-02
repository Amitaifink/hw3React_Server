using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hw3React.DTO
{
    public class IngredientsDto
    {
        public int ingredientId { get; set; }
        public string ingredientName { get; set; }
        public int calories { get; set; }
        public string imgUrl { get; set; }              
    }
}