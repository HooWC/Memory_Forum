using Contracts;
using DomainModelEntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Platform.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private IRepositoryWrapper _repoWrapper;
		public MessageController(IRepositoryWrapper repoWrapper)
		{
			_repoWrapper = repoWrapper;
		}

		[HttpGet]
		public IEnumerable<Message> GetAllMessage()
		{
			return _repoWrapper.Message.FindAll();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Message>> GetMessage(int id)
		{
			var Message = await _repoWrapper.Message.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
			if (Message == null)
			{
				return NotFound();
			}
			return Message;
		}

		[HttpPut("{id}")]
		public IActionResult PutMessage(int id, Message Message)
		{
			if (id != Message.Id)
			{
				return BadRequest();
			}

			_repoWrapper.Message.Update(Message);

			try
			{
				_repoWrapper.Save();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MessageExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return NoContent();
		}

		[HttpPost]
		public ActionResult<Message> PostMessage(Message Message)
		{
			_repoWrapper.Message.Create(Message);
			_repoWrapper.Save();
			return CreatedAtAction("GetMessage", new { id = Message.Id }, Message);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMessage(int id)
		{
			var Message = await _repoWrapper.Message.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
			if (Message == null)
			{
				return NotFound();
			}
			_repoWrapper.Message.Delete(Message);
			_repoWrapper.Save();
			return NoContent();
		}

		private bool MessageExists(int id)
		{
			return _repoWrapper.Message.FindByCondition(e => e.Id == id).Any(e => e.Id == id);
		}
	}
}
