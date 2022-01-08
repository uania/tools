namespace Uania.Tools.Models.SportsTesting
{
    public class SportsTestingUsers
    {
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? UserPhone { get; set; }

        public string? UserEmail { get; set; }

        public int UserRole { get; set; }

        public int UserState { get; set; }

        public string? Password { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpdateTime { get; set; }
    }
}