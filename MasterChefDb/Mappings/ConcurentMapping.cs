﻿using MasterChefDb.Models;
using System.Data.Entity.ModelConfiguration;

namespace MasterChefDb
{
    public class ConcurentMapping : EntityTypeConfiguration<Concurent>
    {
        public ConcurentMapping()
        {
            ToTable("Concurenti");
            HasOptional(x => x.Echipa).WithMany(x => x.Concurenti)
                                      .WillCascadeOnDelete(false);
        }
    }
}
