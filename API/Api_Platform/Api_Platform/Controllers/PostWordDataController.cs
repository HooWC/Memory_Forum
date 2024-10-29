using Contracts;
using DomainModelEntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Platform.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostWordDataController : ControllerBase
	{
		private IRepositoryWrapper _repoWrapper;
		public PostWordDataController(IRepositoryWrapper repoWrapper)
		{
			_repoWrapper = repoWrapper;
		}

		[HttpGet]
		public IEnumerable<PostWordData> GetAllPostWordData()
		{
			return _repoWrapper.PostWordData.FindAll();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<PostWordData>> GetPostWordData(int id)
		{
			var PostWordData = await _repoWrapper.PostWordData.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
			if (PostWordData == null)
			{
				return NotFound();
			}
			return PostWordData;
		}

		[HttpPut("{id}")]
		public IActionResult PutPostWordData(int id, PostWordData PostWordData)
		{
			if (id != PostWordData.Id)
			{
				return BadRequest();
			}

			_repoWrapper.PostWordData.Update(PostWordData);

			try
			{
				_repoWrapper.Save();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PostWordDataExists(id))
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
		public ActionResult<PostWordData> PostPostWordData(PostWordData PostWordData)
		{
			_repoWrapper.PostWordData.Create(PostWordData);
			_repoWrapper.Save();
			return CreatedAtAction("GetPostWordData", new { id = PostWordData.Id }, PostWordData);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePostWordData(int id)
		{
			var PostWordData = await _repoWrapper.PostWordData.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
			if (PostWordData == null)
			{
				return NotFound();
			}
			_repoWrapper.PostWordData.Delete(PostWordData);
			_repoWrapper.Save();
			return NoContent();
		}

		private bool PostWordDataExists(int id)
		{
			return _repoWrapper.PostWordData.FindByCondition(e => e.Id == id).Any(e => e.Id == id);
		}
	}
}
