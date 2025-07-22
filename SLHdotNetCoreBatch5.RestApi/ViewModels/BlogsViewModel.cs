namespace SLHdotNetCoreBatch5.RestApi.ViewModels
{
    public class BlogsViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Content  { get; set; }
        public bool? DeleteFlag { get; set; } // Nullable to allow for default value

    }
}
