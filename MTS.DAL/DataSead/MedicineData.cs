using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MTS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.DAL.DataSead
{
    class MedicineData
    {
        internal static EntityTypeBuilder<Medicine> Seed(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasData(new Medicine[]
            {
                new Medicine()
                {
                    Id="09012020-132323186-4d14c653-461f-426f-ae39",
                    Brand="Abc",
                    Price=Convert.ToDecimal(12.10),
                    Quantity=10,
                    ExpiryDate=DateTime.Now.AddDays(10).Date,
                    Notes="This medicine is for fever"
                }
            });
            return builder;
        }
    }
}
