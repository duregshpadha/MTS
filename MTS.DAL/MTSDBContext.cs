using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MTS.Constants.DALConstants;
using MTS.DAL.ModelConfigurations;
using MTS.DAL.Models;

namespace MTS.DAL
{
    public class MTSDBContext : DbContext
    {
        public MTSDBContext(DbContextOptions<MTSDBContext> options, IConfiguration configuration) : base(options: options)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"],
                    sqlServer => sqlServer.MigrationsHistoryTable(DataBaseConstant.MigrationTable, DataBaseConstant.MigrationSchema));
            }
        }

        public virtual DbSet<Medicine> Medicines { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new MedicineConfiguration());
        }
    }
}
