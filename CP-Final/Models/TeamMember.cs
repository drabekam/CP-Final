using System.ComponentModel.DataAnnotations; // adding this because i needed this to help with the [key] to fix migration error


namespace CP_Final.Models
    
{
    public class TeamMember
    {
        [Key]
        public int MemberID { get; set; } //got a primary key error so hopefully this helps

        public string MemberName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Program { get; set; }
        public string MemberYear { get; set; }
    }
}
