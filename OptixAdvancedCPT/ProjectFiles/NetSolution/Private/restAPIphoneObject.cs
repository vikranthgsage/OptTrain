using System;
using UAManagedCore;

//-------------------------------------------
// WARNING: AUTO-GENERATED CODE, DO NOT EDIT!
//-------------------------------------------

[MapType(NamespaceUri = "OptixAdvancedCPT", Guid = "bdf87a0cca1ce979e506e13e1caabfdf")]
public class restAPIphoneObject : UAObject
{
#region Children properties
    //-------------------------------------------
    // WARNING: AUTO-GENERATED CODE, DO NOT EDIT!
    //-------------------------------------------
    public string Id
    {
        get
        {
            return (string)Refs.GetVariable("Id").Value.Value;
        }
        set
        {
            Refs.GetVariable("Id").SetValue(value);
        }
    }
    public IUAVariable IdVariable
    {
        get
        {
            return (IUAVariable)Refs.GetVariable("Id");
        }
    }
    public string Name
    {
        get
        {
            return (string)Refs.GetVariable("Name").Value.Value;
        }
        set
        {
            Refs.GetVariable("Name").SetValue(value);
        }
    }
    public IUAVariable NameVariable
    {
        get
        {
            return (IUAVariable)Refs.GetVariable("Name");
        }
    }
    public string[] Data
    {
        get
        {
            return (string[])Refs.GetVariable("Data").Value.Value;
        }
        set
        {
            Refs.GetVariable("Data").SetValue(value);
        }
    }
    public IUAVariable DataVariable
    {
        get
        {
            return (IUAVariable)Refs.GetVariable("Data");
        }
    }
#endregion
}
