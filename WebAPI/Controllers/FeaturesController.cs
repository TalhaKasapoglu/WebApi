using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.DTOs.FeatureDTO;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly APIContext _context;

        public FeaturesController(IMapper mapper, APIContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDTO>>(values));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            var value = _mapper.Map<Feature>(createFeatureDTO);

            _context.Features.Add(value);
            _context.SaveChanges();

            return Ok("Feature Created Succesfully!");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);

            _context.Features.Remove(value);
            _context.SaveChanges();

            return Ok("Feature Deleted Succesfully!");
        }

        [HttpGet("GetFeature/ById")]
        public IActionResult GetFeature(int id)
        {
            return Ok(_mapper.Map<GetByIdFeatureDTO>(_context.Features.Find(id)));
        }

        [HttpPut]
        public IActionResult FeatureUpdate(UpdateFeatureDTO updateFeatureDTO)
        {
            var value = _mapper.Map<Feature>(updateFeatureDTO);
            _context.Features.Update(value);
            _context.SaveChanges();

            return Ok("Feature Updated Succesfully!");
        }
    }
}
