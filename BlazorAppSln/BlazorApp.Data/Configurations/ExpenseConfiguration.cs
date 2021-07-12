using BlazorApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Data.Configurations
{
    internal class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> entity)
        {
            entity.Property(p => p.DueDate).HasColumnType("date");
            entity.Property(p => p.Cost).HasPrecision(9, 2);
            //entity.HasQueryFilter(p => !p.SoftDeleted);
        }
    }
}
