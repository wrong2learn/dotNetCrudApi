using dotNetCrudApi.Dtos;
using dotNetCrudApi.Entities;
using dotNetCrudApi.Repositories;

namespace dotNetCrudApi.Services;

public class BlogService : IBlogService
{
    private IPostRepository _postRepo;

    public BlogService(IPostRepository postRepo)
    {
        _postRepo = postRepo;
    }

    public async Task<List<PostDto>> GetAll()
    {
        List<PostDto> posts = new List<PostDto>();
        var postsList = await _postRepo.GetAll();
        if (postsList != null && !postsList.Any())
            return posts;

        posts = postsList.Select(post =>
            new PostDto
            {
                Id = post.Id,
                Content = post.Content,
                Title = post.Title,
                ImageURL = post.ImageURL,
                Published = post.Published
            }).ToList();

        return posts;
    }

    public async Task<PostDto> GetPost(int idPost)
    {
        var post = await _postRepo.GetById(idPost);
        if (post == null)
            return null;

        PostDto resp = new()
        {
            Id = post.Id,
            Content = post.Content,
            Title = post.Title,
            ImageURL = post.ImageURL,
            Published = post.Published,
        };
        return resp;
    }

    public async Task<int> AddAsync(PostDto postDto)
    {
        int postId = 0;
        if (postDto != null)
        {
            var postToAdd = new Post
            {
                Title = postDto.Title,
                ImageURL = postDto.ImageURL,
                Published = postDto.Published,
                Content = postDto.Content,
            };
            postId = await _postRepo.AddAsync(postToAdd);
        }
        return postId;
    }

    public async Task Edit(PostDto postDto)
    {
        var postToUpdate = await _postRepo.GetById(postDto.Id);

        if (postToUpdate != null)
        {
            postToUpdate.Title = postDto.Title;
            postToUpdate.ImageURL = postDto.ImageURL;
            postToUpdate.Published = postDto.Published;
            postToUpdate.Content = postDto.Content;

            await _postRepo.Edit(postToUpdate);
        }
    }

    public async Task Delete(int idPost)
    {
        var postToDelete = await _postRepo.GetById(idPost);
        if (postToDelete != null)
        {
            await _postRepo.Delete(postToDelete);
        }
    }
}
