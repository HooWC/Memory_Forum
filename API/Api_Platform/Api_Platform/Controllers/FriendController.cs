using Contracts;
using DomainModelEntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Platform.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FriendController : ControllerBase
	{
		private IRepositoryWrapper _repoWrapper;
		public FriendController(IRepositoryWrapper repoWrapper)
		{
			_repoWrapper = repoWrapper;
		}

		[HttpGet]
		public IEnumerable<Friend> GetAllFriend()
		{
			return _repoWrapper.Friend.FindAll();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Friend>> GetFriend(int id)
		{
			var Friend = await _repoWrapper.Friend.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
			if (Friend == null)
			{
				return NotFound();
			}
			return Friend;
		}

		[HttpPut("{id}")]
		public IActionResult PutFriend(int id, Friend Friend)
		{
			if (id != Friend.Id)
			{
				return BadRequest();
			}

			_repoWrapper.Friend.Update(Friend);

			try
			{
				_repoWrapper.Save();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!FriendExists(id))
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
		public ActionResult<Friend> PostFriend(Friend Friend)
		{
			_repoWrapper.Friend.Create(Friend);
			_repoWrapper.Save();
			return CreatedAtAction("GetFriend", new { id = Friend.Id }, Friend);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteFriend(int id)
		{
			var Friend = await _repoWrapper.Friend.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
			if (Friend == null)
			{
				return NotFound();
			}
			_repoWrapper.Friend.Delete(Friend);
			_repoWrapper.Save();
			return NoContent();
		}

		private bool FriendExists(int id)
		{
			return _repoWrapper.Friend.FindByCondition(e => e.Id == id).Any(e => e.Id == id);
		}
	}
}
