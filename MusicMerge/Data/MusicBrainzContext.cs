using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicMerge;

namespace MusicMerge.Data
{
    public class MusicBrainzContext : DbContext
    {
        public MusicBrainzContext (DbContextOptions<MusicMergeContext> options)
            : base(options)
        {
        }
    }
}
