namespace CP_Final.Models
{
    public class FavoriteFood
    {
        public int Id { get; set; }
        public int MemberID { get; set; }
        public string FoodName { get; set; } //changingName to remove error
        public string FoodCategory { get; set; }
        public string Flavor { get; set; }
        public string ForkSpoonHands { get; set; }
    }
}
