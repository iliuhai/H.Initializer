using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Initializer.Model;

namespace Test.Initializer.Model
{
    public class SampleMap : IEntityTypeConfiguration<SampleEntity>
    {
        public virtual void Configure(EntityTypeBuilder<SampleEntity> builder)
        {
            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Desc).IsRequired(false);
        }
    }
}
