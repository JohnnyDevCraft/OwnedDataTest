using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using Microsoft.Extensions.DependencyInjection;

namespace OwnedDataTest.Module.BusinessObjects;

public class Child
{
    public virtual string Name { get; set; }
    
    public virtual string Other { get; set; }
}