using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace CP_Final.Models
    public class DBContext : DbContext
    {
        public virtual DbSet<TeamMember> TeamMembers {get; set;}

        public virtual DbSet<Hobby> Hobbies {get; set;}

        public virtual DbSet<FavoriteSeason> FavoriteSeasons {get; set;}

        public virtual DbSet<FavoriteFood> FavoriteFoods {get; set;}

        public DBContext(DbContextOptions options) : base(options) {
        
        }
    }