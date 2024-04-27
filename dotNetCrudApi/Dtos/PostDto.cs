namespace dotNetCrudApi.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Published { get; set; }
        public string ImageURL { get; set; }
        public string Content { get; set; }
    }
}
