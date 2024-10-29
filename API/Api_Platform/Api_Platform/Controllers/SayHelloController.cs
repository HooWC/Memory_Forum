using Contracts;
using DomainModelEntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Platform.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SayHelloController : ControllerBase
	{
		private IRepositoryWrapper _repoWrapper;
		public SayHelloController(IRepositoryWrapper repoWrapper)
		{
			_repoWrapper = repoWrapper;
		}

		[HttpGet]
		public IEnumerable<SayHello> GetAllSayHello()
		{
			return _repoWrapper.SayHello.FindAll();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<SayHello>> GetSayHello(int id)
		{
			var SayHello = await _repoWrapper.SayHello.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
			if (SayHello == null)
			{
				return NotFound();
			}
			return SayHello;
		}

		[HttpPut("{id}")]
		public IActionResult PutSayHello(int id, SayHello SayHello)
		{
			if (id != SayHello.Id)
			{
				return BadRequest();
			}

			_repoWrapper.SayHello.Update(SayHello);

			try
			{
				_repoWrapper.Save();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!SayHelloExists(id))
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
		public ActionResult<SayHello> PostSayHello(SayHello SayHello)
		{
			_repoWrapper.SayHello.Create(SayHello);
			_repoWrapper.Save();
			return CreatedAtAction("GetSayHello", new { id = SayHello.Id }, SayHello);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSayHello(int id)
		{
			var SayHello = await _repoWrapper.SayHello.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
			if (SayHello == null)
			{
				return NotFound();
			}
			_repoWrapper.SayHello.Delete(SayHello);
			_repoWrapper.Save();
			return NoContent();
		}

		private bool SayHelloExists(int id)
		{
			return _repoWrapper.SayHello.FindByCondition(e => e.Id == id).Any(e => e.Id == id);
		}
	}
}
