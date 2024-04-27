using dotNetCrudApi.Dtos;
using dotNetCrudApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotNetCrudApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class PostController : ControllerBase
{
    private IBlogService _blogService;

    public PostController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpGet]
    [Route("/api/posts/get/{idPost}")]
    public async Task<IActionResult> get(int idPost)
    {
        PostDto post = null;
        try
        {
            var postFound = await _blogService.GetPost(idPost);
            if (postFound == null)
                return NotFound("Post not exists.");
            else
            {
                post = new PostDto();
                post = postFound;
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok(post);
    }

    [HttpGet]
    [Route("/api/posts/getAll")]
    public async Task<IActionResult> getAll()
    {
        List<PostDto> posts = null;
        try
        {
            var postsFound = await _blogService.GetAll();
            posts = postsFound;
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok(posts);
    }

    [HttpPost]
    [Route("/api/posts/add")]
    public async Task<IActionResult> Add(PostDto postDto)
    {
        int postId = 0;
        try
        {
            postId = await _blogService.AddAsync(postDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok(postId);
    }

    [HttpPut]
    [Route("/api/posts/update")]
    public async Task<IActionResult> Update(PostDto postDto)
    {
        try
        {
            await _blogService.Edit(postDto);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }

    [HttpDelete]
    [Route("/api/posts/delete/{idPost}")]
    public async Task<IActionResult> Delete(int idPost)
    {
        try
        {
            await _blogService.Delete(idPost);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }

}
