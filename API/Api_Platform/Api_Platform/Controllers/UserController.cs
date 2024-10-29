using Contracts;
using DomainModelEntity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Platform.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize]
	public class UserController : ControllerBase
	{
		private IRepositoryWrapper _repoWrapper;
		public UserController(IRepositoryWrapper repoWrapper)
		{
			_repoWrapper = repoWrapper;
		}

		[HttpGet]
		public IEnumerable<User> GetAllUser()
		{
			return _repoWrapper.User.FindAll();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetUser(int id)
		{
			var User = await _repoWrapper.User.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
			if (User == null)
			{
				return NotFound();
			}
			return User;
		}

		[HttpPut("{id}")]
		public IActionResult PutUser(int id, User User)
		{
			if (id != User.Id)
			{
				return BadRequest();
			}

			_repoWrapper.User.Update(User);

			try
			{
				_repoWrapper.Save();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!UserExists(id))
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
		public ActionResult<User> PostUser(User User)
		{
			_repoWrapper.User.Create(User);
			_repoWrapper.Save();
			return CreatedAtAction("GetUser", new { id = User.Id }, User);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			var User = await _repoWrapper.User.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
			if (User == null)
			{
				return NotFound();
			}
			_repoWrapper.User.Delete(User);
			_repoWrapper.Save();
			return NoContent();
		}

		private bool UserExists(int id)
		{
			return _repoWrapper.User.FindByCondition(e => e.Id == id).Any(e => e.Id == id);
		}
	}
}
