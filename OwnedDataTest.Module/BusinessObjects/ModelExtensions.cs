using Microsoft.EntityFrameworkCore;

namespace OwnedDataTest.Module.BusinessObjects;

public static class ModelExtensions
{
    public static ModelBuilder AddBaseModel(this ModelBuilder mb)
    {

        mb.Entity<Parent>(entity =>
        {
            entity.HasKey(e => e.ID);

            entity.OwnsOne(e => e.Child);
        });

        return mb;
    }
}
