using dotNetCrudApi.Entities;

namespace dotNetCrudApi.Repositories;
public interface IPostRepository
{
    Task<List<Post>?> GetAll();
    Task<Post?> GetById(int idPost);
    Task<int> AddAsync(Post post);
    Task Edit(Post post);
    Task Delete(Post post);
}
