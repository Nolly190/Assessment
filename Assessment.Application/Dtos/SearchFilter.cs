namespace Assessment.Application.Dtos
{
    public class SearchFilter : PaginationFilter
    {
        public Dictionary<string, string> SearchParams { get; set; } = new Dictionary<string, string>();
    }
}
