namespace Mission11_ajames26.Models.ViewModels
{
    public class PageInfo
    {
        public int NumBooks { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (NumBooks / PageSize) + 1;
    }
}
