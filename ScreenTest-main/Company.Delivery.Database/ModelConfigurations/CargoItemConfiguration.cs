﻿using Company.Delivery.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Delivery.Database.ModelConfigurations;

internal class CargoItemConfiguration : IEntityTypeConfiguration<CargoItem>
{
    public void Configure(EntityTypeBuilder<CargoItem> builder)
    {
        // TODO: все строковые свойства должны иметь ограничение на длину
        // TODO: должно быть ограничение на уникальность свойства CargoItem.Number в пределах одной сущности Waybill
        // TODO: ApplicationDbContextTests должен выполняться без ошибок

        builder.HasIndex(p => new { p.Number, p.WaybillId }).IsUnique();
        builder.Property(x => x.Number).HasMaxLength(20);
        builder.Property(x => x.Name).HasMaxLength(60);

        builder.HasOne(x => x.Waybill).WithMany(x => x.Items);
    }
}