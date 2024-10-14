using Microsoft.EntityFrameworkCore;
using TodoList.Core.Model;

namespace TodoList.Infrastructure.Persistence.Repositories
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        { }
        public DbSet<TaskTodo> TaskTodo { get; set; }   
        public DbSet<Comment> Comment { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskTodo>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Comment>()
             .HasKey(t => t.Id);



            modelBuilder.Entity<Comment>()
       .Property(t => t.Id)
       .ValueGeneratedOnAdd();

        }
    }
}
