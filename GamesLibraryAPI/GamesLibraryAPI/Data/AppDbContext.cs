﻿using GamesLibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesLibraryAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<Game> Games { get; set; }
    }
}
