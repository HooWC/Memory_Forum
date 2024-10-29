using Contracts;
using DomainModelEntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Platform.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageCallController : ControllerBase
	{
		private IRepositoryWrapper _repoWrapper;
		public MessageCallController(IRepositoryWrapper repoWrapper)
		{
			_repoWrapper = repoWrapper;
		}

		[HttpGet]
		public IEnumerable<MessageCall> GetAllMessageCall()
		{
			return _repoWrapper.MessageCall.FindAll();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<MessageCall>> GetMessageCall(int id)
		{
			var MessageCall = await _repoWrapper.MessageCall.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
			if (MessageCall == null)
			{
				return NotFound();
			}
			return MessageCall;
		}

		[HttpPut("{id}")]
		public IActionResult PutMessageCall(int id, MessageCall MessageCall)
		{
			if (id != MessageCall.Id)
			{
				return BadRequest();
			}

			_repoWrapper.MessageCall.Update(MessageCall);

			try
			{
				_repoWrapper.Save();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MessageCallExists(id))
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
		public ActionResult<MessageCall> PostMessageCall(MessageCall MessageCall)
		{
			_repoWrapper.MessageCall.Create(MessageCall);
			_repoWrapper.Save();
			return CreatedAtAction("GetMessageCall", new { id = MessageCall.Id }, MessageCall);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMessageCall(int id)
		{
			var MessageCall = await _repoWrapper.MessageCall.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
			if (MessageCall == null)
			{
				return NotFound();
			}
			_repoWrapper.MessageCall.Delete(MessageCall);
			_repoWrapper.Save();
			return NoContent();
		}

		private bool MessageCallExists(int id)
		{
			return _repoWrapper.MessageCall.FindByCondition(e => e.Id == id).Any(e => e.Id == id);
		}
	}
}
