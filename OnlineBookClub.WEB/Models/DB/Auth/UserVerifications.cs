namespace OnlineBookClub.WEB.Models.DB.Auth
{
    public class UserVerifications
    {
        public Guid UserId { get; set; }
        public Guid Guid { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public DateTimeOffset ConfirmedDate { get; set; }
        public DateTimeOffset CREATE_DATE { get; set; }

    }
}
