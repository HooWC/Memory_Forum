using Contracts;
using DomainModelEntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Platform.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostWordDataCommentController : ControllerBase
	{
		private IRepositoryWrapper _repoWrapper;
		public PostWordDataCommentController(IRepositoryWrapper repoWrapper)
		{
			_repoWrapper = repoWrapper;
		}

		[HttpGet]
		public IEnumerable<PostWordDataComment> GetAllPostWordDataComment()
		{
			return _repoWrapper.PostWordDataComment.FindAll();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<PostWordDataComment>> GetPostWordDataComment(int id)
		{
			var PostWordDataComment = await _repoWrapper.PostWordDataComment.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
			if (PostWordDataComment == null)
			{
				return NotFound();
			}
			return PostWordDataComment;
		}

		[HttpPut("{id}")]
		public IActionResult PutPostWordDataComment(int id, PostWordDataComment PostWordDataComment)
		{
			if (id != PostWordDataComment.Id)
			{
				return BadRequest();
			}

			_repoWrapper.PostWordDataComment.Update(PostWordDataComment);

			try
			{
				_repoWrapper.Save();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PostWordDataCommentExists(id))
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
		public ActionResult<PostWordDataComment> PostPostWordDataComment(PostWordDataComment PostWordDataComment)
		{
			_repoWrapper.PostWordDataComment.Create(PostWordDataComment);
			_repoWrapper.Save();
			return CreatedAtAction("GetPostWordDataComment", new { id = PostWordDataComment.Id }, PostWordDataComment);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePostWordDataComment(int id)
		{
			var PostWordDataComment = await _repoWrapper.PostWordDataComment.FindByCondition(e => e.Id == id).FirstOrDefaultAsync();
			if (PostWordDataComment == null)
			{
				return NotFound();
			}
			_repoWrapper.PostWordDataComment.Delete(PostWordDataComment);
			_repoWrapper.Save();
			return NoContent();
		}

		private bool PostWordDataCommentExists(int id)
		{
			return _repoWrapper.PostWordDataComment.FindByCondition(e => e.Id == id).Any(e => e.Id == id);
		}
	}
}
