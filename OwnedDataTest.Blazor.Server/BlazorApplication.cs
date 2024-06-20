using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.SystemModule;
using OwnedDataTest.Module.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using DevExpress.ExpressApp.EFCore;

namespace OwnedDataTest.Blazor.Server;

public class OwnedDataTestBlazorApplication : BlazorApplication {
    public OwnedDataTestBlazorApplication() {
        ApplicationName = "OwnedDataTest";
        CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.ModuleInfo;
        DatabaseVersionMismatch += OwnedDataTestBlazorApplication_DatabaseVersionMismatch;
    }
    protected override void OnSetupStarted() {
        base.OnSetupStarted();
        if(CheckCompatibilityType == CheckCompatibilityType.ModuleInfo) {
            DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
        }
    }
    private void OwnedDataTestBlazorApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e) {

        e.Updater.Update();
        e.Handled = true;

    }
}
