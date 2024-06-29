﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesFilme.Model;

namespace RazorPagesFilmes.Data
{
    public class RazorPagesFilmesContext : DbContext
    {
        public RazorPagesFilmesContext (DbContextOptions<RazorPagesFilmesContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesFilme.Model.Movie> Movie { get; set; } = default!;
    }
}
