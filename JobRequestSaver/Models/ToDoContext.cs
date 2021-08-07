using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AboutFindingJob.Models
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoItem> toDoItems { get; set; }
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
           
        }
    }
}
