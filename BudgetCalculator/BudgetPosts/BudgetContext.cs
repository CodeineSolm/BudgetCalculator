using System.Data.Entity;

namespace BudgetPosts
{
    public class BudgetContext : DbContext
    {
        public BudgetContext() : base("BCConnection")
        {

        }
        DbSet<Posts> Posts { get; set; }
    }
}
