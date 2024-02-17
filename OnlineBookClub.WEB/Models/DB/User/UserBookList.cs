using OnlineBookClub.WEB.Models.DB.Const;

namespace OnlineBookClub.WEB.Models.DB.User
{
    public class UserBookList
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;

        public string ISBN { get; set; } = null!;

        public byte UserBookListTypeId { get; set; }

        public virtual UserBookListType UserBookListType { get; set; }
    }
}
