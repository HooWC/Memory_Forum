using Contracts;
using DomainModelEntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Platform.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostWordController : ControllerBase
	{
		private IRepositoryWrapper _repoWrapper;
		public PostWordController(IRepositoryWrapper repoWrapper)
		{
			_repoWrapper = repoWrapper;
		}

		[HttpGet]
		public IEnumerable<PostWord> GetAllPostWord()
		{
			return _repoWrapper.PostWord.FindAll();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<PostWord>> GetPostWord(int id)
		{
			var PostWord = await _repoWrapper.PostWord.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
			if (PostWord == null)
			{
				return NotFound();
			}
			return PostWord;
		}

		[HttpPut("{id}")]
		public IActionResult PutPostWord(int id, PostWord PostWord)
		{
			if (id != PostWord.Id)
			{
				return BadRequest();
			}

			_repoWrapper.PostWord.Update(PostWord);

			try
			{
				_repoWrapper.Save();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PostWordExists(id))
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
		public ActionResult<PostWord> PostPostWord(PostWord PostWord)
		{
			_repoWrapper.PostWord.Create(PostWord);
			_repoWrapper.Save();
			return CreatedAtAction("GetPostWord", new { id = PostWord.Id }, PostWord);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePostWord(int id)
		{
			var PostWord = await _repoWrapper.PostWord.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
			if (PostWord == null)
			{
				return NotFound();
			}
			_repoWrapper.PostWord.Delete(PostWord);
			_repoWrapper.Save();
			return NoContent();
		}

		private bool PostWordExists(int id)
		{
			return _repoWrapper.PostWord.FindByCondition(e => e.Id == id).Any(e => e.Id == id);
		}
	}
}
