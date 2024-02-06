namespace BoslaAPI.Models
{
    public class Child
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Gender { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? ProfileImage { get; set; }
        public string RelativeName { get; set; } = null!;
        public string RelativePhone { get; set; } = null!;
    }
}
