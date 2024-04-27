using dotNetCrudApi.DatabaseContext;
using dotNetCrudApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotNetCrudApi.Repositories;

public class PostRepository : IPostRepository
{
    private BlogDbContext _blogDbContext;

    public PostRepository(BlogDbContext blogDbContext)
    {
        _blogDbContext = blogDbContext;
    }

    public async Task<List<Post>> GetAll()
    {
        return await _blogDbContext.Posts
            .ToListAsync();
    }

    public async Task<Post?> GetById(int idPost)
    {
        return await _blogDbContext.Posts
                .SingleOrDefaultAsync(p => p.Id == idPost);
    }

    public async Task<int> AddAsync(Post post)
    {
        var postSaved = _blogDbContext.Posts.Add(post);
        await _blogDbContext.SaveChangesAsync();
        return postSaved.Entity.Id;
    }

    public async Task Edit(Post post)
    {
        _blogDbContext.Update(post);
        await _blogDbContext.SaveChangesAsync();
    }

    public async Task Delete(Post post)
    {
        _blogDbContext.Remove(post);
        await _blogDbContext.SaveChangesAsync();
    }
}
