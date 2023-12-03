namespace CP_Final.Models
{
    public class FavoriteSeason
    {
        public int Id { get; set; }
        public int MemberID { get; set; }
        public string SeasonName { get; set; } //changing to fix error
        public string Weather { get; set; }
        public string Holidays { get; set; }
        public string Reason { get; set; }
    }
}
