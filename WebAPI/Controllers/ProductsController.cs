using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.DTOs.ProductDTO;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly APIContext _context;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<Product> validator, APIContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _context.Products.ToList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);

            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult.Errors.Select(p => p.ErrorMessage));
            //}

            //return Ok(new { message = "Product Added Successfully!", data = product });

            if (validationResult.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                return Ok(new { message = "Product Added Successfully!", data = product });
            }
            return BadRequest(validationResult.Errors.Select(p => p.ErrorMessage));
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);

            _context.Products.Remove(value);
            _context.SaveChanges();

            return Ok("Product Deleted Succesfully!");
        }

        [HttpGet("GetProduct/ById")]
        public IActionResult GetProductById(int id)
        {
            return Ok(_context.Products.Find(id));
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);

            if (validationResult.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();

                return Ok(new { message = "Product Updated Successfully!", data = product });
            }
            return BadRequest(validationResult.Errors.Select(p => p.ErrorMessage));
        }

        [HttpPost("CreateCategory/WithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDTO createProductDTO)
        {
            var value = _mapper.Map<Product>(createProductDTO);
            var validationResult = _validator.Validate(value);

            if ( validationResult.IsValid)
            {
                _context.Products.Add(value);
                _context.SaveChanges();

                return Ok(new { message = "Product Added Successfully!", data = value });
            }
            return BadRequest(validationResult.Errors.Select(p => validationResult.Errors));
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var value = _context.Products.Include(p => p.Category).ToList();

            return Ok(_mapper.Map<List<ResultProductWithCategoryDTO>>(value));
        }
    }
}
