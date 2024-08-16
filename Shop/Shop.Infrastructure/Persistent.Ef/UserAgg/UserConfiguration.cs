using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.UserAgg;

namespace Shop.Infrastructure.Persistent.Ef.UserAgg;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable("Users", "user");
		builder.HasIndex(b => b.PhoneNumber).IsUnique();
		builder.HasIndex(b => b.Email).IsUnique();

		builder.Property(b => b.Email)
		    .IsRequired(false)
		    .HasMaxLength(256);

		builder.Property(b => b.PhoneNumber)
		    .IsRequired()
		    .HasMaxLength(11);

		builder.Property(b => b.FirstName)
		    .IsRequired(false)

		   .HasMaxLength(80);

		builder.Property(b => b.LastName)
		    .IsRequired(false)
		    .HasMaxLength(80);

		builder.Property(b => b.Password)
		    .IsRequired()
		    .HasMaxLength(50);




		builder.OwnsMany(b => b.Addresses, option =>
		{
			option.HasIndex(b => b.UserId);
			option.ToTable("Addresses", "user");

			option.Property(b => b.Shire)
			   .IsRequired().HasMaxLength(100);

			option.Property(b => b.City)
			  .IsRequired().HasMaxLength(100);

			option.Property(b => b.FirstName)
			 .IsRequired().HasMaxLength(50);

			option.Property(b => b.LastName)
			  .IsRequired().HasMaxLength(50);


			option.Property(b => b.NationalCode)
			  .IsRequired().HasMaxLength(10);

			option.Property(b => b.PostalCode)
			  .IsRequired().HasMaxLength(20);

			option.OwnsOne(c => c.PhoneNumber, config =>
		   {
			   config.Property(b => b.Value)
				.HasColumnName("PhoneNumber")
				.IsRequired().HasMaxLength(11);
		   });

		});
		builder.OwnsMany(b => b.Tokens, option =>
		{
			option.ToTable("Tokens", "user");
			option.HasKey(k => k.Id);
			option.Property(p => p.HashJwtToken)
				.IsRequired()
				.HasMaxLength(300);
			option.Property(p => p.HashRefreshToken)
				.IsRequired()
				.HasMaxLength(300);
			option.Property(p => p.Device)
				.IsRequired()
				.HasMaxLength(100);
		});
		builder.OwnsMany(b => b.Wallets, option =>
		{
			option.ToTable("Wallets", "user");
			option.HasIndex(b => b.UserId);

			option.Property(b => b.Description)
			  .IsRequired(false)
			  .HasMaxLength(500);
		});

		builder.OwnsMany(b => b.Roles, option =>
		{
			option.ToTable("Roles", "user");
			option.HasIndex(b => b.UserId);
		});
	}
}
