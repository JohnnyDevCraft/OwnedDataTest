# OwnedDataTest
This is a test project to test the Viability of using Owned Data in EFCore with XAF.

When loading the view with the default data the following error is produced:

```stacktrace
System.ArgumentException: A business class OwnedDataTest.Module.BusinessObjects.Child without a public key property may cause issues with selection, filtering, etc. in a ListView Child_LookupListView. If your class is non-persistent, inherit it from DevExpress.ExpressApp.NonPersistentLiteObject or DevExpress.ExpressApp.NonPersistentBaseObject or declare a public key property with DevExpress.ExpressApp.Data.KeyAttribute. For more information, see https://www.devexpress.com/kb=T639653.
         at DevExpress.ExpressApp.XafApplication.CreateListView(String listViewId, IModelListView modelListView, CollectionSourceBase collectionSource, Boolean isRoot, ListEditor listEditor)
         at DevExpress.ExpressApp.XafApplication.CreateListView(IModelListView modelListView, CollectionSourceBase collectionSource, Boolean isRoot, ListEditor listEditor)
         at DevExpress.ExpressApp.XafApplication.CreateListView(IModelListView modelListView, CollectionSourceBase collectionSource, Boolean isRoot)
         at DevExpress.ExpressApp.Blazor.Internal.BlazorLookupEditorHelper.CreateListViewWithGridListEditor(Object editingObject)
         at DevExpress.ExpressApp.Blazor.Editors.LookupPropertyEditor.RecreateListView()
         at DevExpress.ExpressApp.Blazor.Editors.LookupPropertyEditor.InitializeFrame()
         at DevExpress.ExpressApp.Blazor.Editors.LookupPropertyEditor.CreateComponentAdapter[T]()
         at DevExpress.ExpressApp.Blazor.Editors.LookupPropertyEditor.CreateComponentAdapter()
         at DevExpress.ExpressApp.Blazor.Editors.BlazorPropertyEditorBase.CreateControlCore()
         at DevExpress.ExpressApp.Editors.ViewItem.CreateControl()
         at DevExpress.ExpressApp.Blazor.Layout.BlazorLayoutComponentBase.GetControlComponentContent(ViewItem viewItem)
         at DevExpress.ExpressApp.Blazor.Layout.LayoutComponent.<>c__DisplayClass6_0.<CreateItem>b__1(RenderTreeBuilder __builder)
         at Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.AddContent(Int32 sequence, RenderFragment fragment)
         at DevExpress.Blazor.DxFormLayoutItem.<>c__DisplayClass36_0.<GetTemplate>b__1(RenderTreeBuilder builder)
         at Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.AddContent(Int32 sequence, RenderFragment fragment)
         at DevExpress.Blazor.DxFormLayoutItem.BuildRenderTree(RenderTreeBuilder __builder)
         at DevExpress.Blazor.Base.DxComponentBase.BuildRootLayout(RenderTreeBuilder builder)
         at DevExpress.Blazor.Base.DxComponentBase.BuildRenderTreeCore(RenderTreeBuilder builder)
         at Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.AddContent(Int32 sequence, RenderFragment fragment)
         at DevExpress.Blazor.Base.DxDecoratedComponent.BuildRenderTree(RenderTreeBuilder builder)
         at Microsoft.AspNetCore.Components.Rendering.ComponentState.RenderIntoBatch(RenderBatchBuilder batchBuilder, RenderFragment renderFragment, Exception& renderFragmentException)

```

This clearly indicates that the issue is with the Child class. The Child class is an Owned class on the parent, and 
therefore does not have a key property. This is a limitation of EFCore. XAF does not support this out of the box.

```csharp
mb.Entity<Parent>(entity =>
{
    entity.HasKey(e => e.ID);

    entity.OwnsOne(e => e.Child);
});
```

## Final Conclusion
Owned Data is not supported in XAF. This is due to the fact that EFCore does not support this out of the box.