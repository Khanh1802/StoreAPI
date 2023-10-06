namespace API.RequestHelpers
{
    public class PaginationParams
    {
        private const int _maxPageSize = 50; //the number of max result on 1 page
        public int PageNumber { get; set; } = 1; // default 1 when call the first page
        private int _pageSize = 5; //the result show on page
        public int PageSize
        {
            get => _pageSize; // return _pageSize
            set => _pageSize = value > _maxPageSize ? _maxPageSize : value;
        }
    }
}
