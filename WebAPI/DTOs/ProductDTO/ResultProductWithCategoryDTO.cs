﻿using WebAPI.Entities;

namespace WebAPI.DTOs.ProductDTO
{
    public class ResultProductWithCategoryDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName{ get; set; }
    }
}
