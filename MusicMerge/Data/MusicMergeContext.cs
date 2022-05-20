using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicMerge;

namespace MusicMerge.Data
{
    public class MusicMergeContext : DbContext
    {
        public MusicMergeContext (DbContextOptions<MusicMergeContext> options)
            : base(options)
        {
        }

        public DbSet<MusicMerge.Album> Albums { get; set; }

        public DbSet<MusicMerge.GeneratedImage> GeneratedImages { get; set; }

        public DbSet<MusicMerge.User> Users { get; set; }
    }
}
