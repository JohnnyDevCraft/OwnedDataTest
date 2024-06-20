using Azure.Core;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using Microsoft.Extensions.DependencyInjection;

namespace OwnedDataTest.Module.BusinessObjects;

[DefaultClassOptions]
public class Parent : BaseObject
{
    public virtual string Name { get; set; }
    
    public virtual string Description { get; set; }

    public virtual Child Child { get; set; }
    
}