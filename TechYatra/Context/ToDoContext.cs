﻿using Microsoft.EntityFrameworkCore;
using TechYatra.Model;

namespace TechYatra.Context
{
    public class ToDoContext:DbContext
    {
        public ToDoContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
