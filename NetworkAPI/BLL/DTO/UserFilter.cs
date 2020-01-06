namespace BLL.DTO
{
    public class UserFilter
    {
        private const int MaxSize = 30;
        public int CurrentPage { get; set; } = 1;
        private int pageSize = 15;
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value > MaxSize ? MaxSize : value;
            }
        }

        public int MaxHumanAge { get; set; } = 126;
        public int MinHumanAge { get; set; } = 12;

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
    }
}
