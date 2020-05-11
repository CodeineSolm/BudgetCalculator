using System.Data.Entity;

namespace BudgetPosts
{
    public class BudgetContext : DbContext
    {
        public BudgetContext() : base("BCConnection")
        {

        }
        public DbSet<Posts> Posts { get; set; }
    }
}
