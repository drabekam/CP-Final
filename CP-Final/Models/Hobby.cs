namespace CP_Final.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public int MemberID { get; set; }
        public string HobbyName { get; set; } //Changing to fix error
        public string HoursPerWeek { get; set; }
        public string StartedHobby { get; set; }
        public string Description { get; set; }
    }
}
