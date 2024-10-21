using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using MyMoneyAPI.Models;

namespace MyMoneyAPI.Data.EntityMapping
{
    public class AccountConfiguration : IEntityTypeConfiguration<AccountEntity>
    {
        public void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            // Primary key
            builder.HasKey(e => e.AccountId);

            //Properties
            builder.Property(e => e.AccountName);
            builder.Property(e => e.BaseAmount);
            builder.Property(e => e.Balance);
            builder.Property(e => e.Icon);

            //Audit Properties
            builder.Property(e => e.CreatedBy);
            builder.Property(e => e.CreatedDate);
            builder.Property(e => e.ModifiedBy);
            builder.Property(e => e.ModifiedDate);
            builder.Property(e => e.IsActive);

            // Table name
            builder.ToTable("Accounts");

        }
    }
}
