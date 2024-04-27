using dotNetCrudApi.Dtos;

namespace dotNetCrudApi.Services;
public interface IBlogService
{
    Task<PostDto> GetPost(int idPost);
    Task<List<PostDto>> GetAll();
    Task<int> AddAsync(PostDto postDto);
    Task Edit(PostDto postDto);
    Task Delete(int idPost);
}
