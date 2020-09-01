using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTS.Constants.DALConstants;
using MTS.DAL.DataSead;
using MTS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.DAL.ModelConfigurations
{
    class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.ToTable(nameof(Medicine), SchemaConstant.DBO);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasMaxLength(MaxLengthConstant.ID).IsRequired();
            builder.Property(e => e.Brand).HasMaxLength(MaxLengthConstant.ShortStringLenght).IsRequired();
            builder.Property(e => e.Price).HasColumnType("decimal(16, 2)").IsRequired();
            builder.Property(e => e.Quantity).IsRequired();
            builder.Property(e => e.ExpiryDate).HasColumnType("date").IsRequired();
            builder.Property(e => e.Notes).HasMaxLength(MaxLengthConstant.LongStringLenght).IsRequired();
            MedicineData.Seed(builder);
        }
    }
}
