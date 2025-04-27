using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.DTOs.MessageDTO;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly APIContext _context;

        public MessagesController(IMapper mapper, APIContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList();

            return Ok(_mapper.Map<List<ResultMessageDTO>>(values));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDTO createMessageDTO)
        {
           var value =  _mapper.Map<Message>(createMessageDTO);

            _context.Messages.Add(value);
            _context.SaveChanges();

            return Ok("Message Created Succesfully!");
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);

            _context.Messages.Remove(value);
            _context.SaveChanges();

            return Ok("Message Deleted Successfully!");
        }

        [HttpGet("GetMessage/ById")]
        public IActionResult GetMessageById(int id)
        {
            return Ok(_mapper.Map<GetByIdMessageDTO>(_context.Messages.Find(id)));
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDTO updateMessageDTO)
        {
            var value = _mapper.Map<Message>(updateMessageDTO);

            _context.Messages.Update(value);
            _context.SaveChanges();

            return Ok("Message Update Successfully!");
        }
    }
}
