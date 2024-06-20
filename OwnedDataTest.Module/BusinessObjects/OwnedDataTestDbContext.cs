using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;

namespace OwnedDataTest.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class OwnedDataTestContextInitializer : DbContextTypesInfoInitializerBase {
	protected override DbContext CreateDbContext() {
		var cst = "Server=localhost;Database=test1;User=root;Password=***;Port=3306";
		var optionsBuilder = new DbContextOptionsBuilder<OwnedDataTestEFCoreDbContext>()
			.UseMySql(cst, ServerVersion.AutoDetect(cst))
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new OwnedDataTestEFCoreDbContext(optionsBuilder.Options);
	}
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class OwnedDataTestDesignTimeDbContextFactory : IDesignTimeDbContextFactory<OwnedDataTestEFCoreDbContext> {
	public OwnedDataTestEFCoreDbContext CreateDbContext(string[] args)
	{
		var cst = "Server=localhost;Database=test1;User=root;Password=***;Port=3306";
		var optionsBuilder = new DbContextOptionsBuilder<OwnedDataTestEFCoreDbContext>();
		optionsBuilder.UseMySql(cst, ServerVersion.AutoDetect(cst));
        optionsBuilder.UseChangeTrackingProxies();
        optionsBuilder.UseObjectSpaceLinkProxies();
		return new OwnedDataTestEFCoreDbContext(optionsBuilder.Options);
	}
}
[TypesInfoInitializer(typeof(OwnedDataTestContextInitializer))]
public class OwnedDataTestEFCoreDbContext : DbContext {
	public OwnedDataTestEFCoreDbContext(DbContextOptions<OwnedDataTestEFCoreDbContext> options) : base(options) {
	}
	public DbSet<ModuleInfo> ModulesInfo { get; set; }
	public DbSet<Parent> Parents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
        modelBuilder.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
        modelBuilder.AddBaseModel();
    }
}
