namespace Uania.Tools.Repository.Entities
{
    public class SportsTestingUser : SportsTestingBaseEntity
    {
        public string? UserName { get; set; }

        public string? UserPhone { get; set; }

        public string? UserEmail { get; set; }

        public int UserRole { get; set; }

        public int UserState { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}