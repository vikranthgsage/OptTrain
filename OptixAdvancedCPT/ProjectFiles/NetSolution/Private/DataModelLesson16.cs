using System;
using UAManagedCore;

//-------------------------------------------
// WARNING: AUTO-GENERATED CODE, DO NOT EDIT!
//-------------------------------------------

[MapType(NamespaceUri = "OptixAdvancedCPT", Guid = "64c76dcd7c64d8325c69c0b7ebfb01b7")]
public class DataModelLesson16 : UAObject
{
#region Children properties
    //-------------------------------------------
    // WARNING: AUTO-GENERATED CODE, DO NOT EDIT!
    //-------------------------------------------
    public int Variable1
    {
        get
        {
            return (int)Refs.GetVariable("Variable1").Value.Value;
        }
        set
        {
            Refs.GetVariable("Variable1").SetValue(value);
        }
    }
    public IUAVariable Variable1Variable
    {
        get
        {
            return (IUAVariable)Refs.GetVariable("Variable1");
        }
    }
    public int Variable2
    {
        get
        {
            return (int)Refs.GetVariable("Variable2").Value.Value;
        }
        set
        {
            Refs.GetVariable("Variable2").SetValue(value);
        }
    }
    public IUAVariable Variable2Variable
    {
        get
        {
            return (IUAVariable)Refs.GetVariable("Variable2");
        }
    }
    public int Variable3
    {
        get
        {
            return (int)Refs.GetVariable("Variable3").Value.Value;
        }
        set
        {
            Refs.GetVariable("Variable3").SetValue(value);
        }
    }
    public IUAVariable Variable3Variable
    {
        get
        {
            return (IUAVariable)Refs.GetVariable("Variable3");
        }
    }
    public int Variable4
    {
        get
        {
            return (int)Refs.GetVariable("Variable4").Value.Value;
        }
        set
        {
            Refs.GetVariable("Variable4").SetValue(value);
        }
    }
    public IUAVariable Variable4Variable
    {
        get
        {
            return (IUAVariable)Refs.GetVariable("Variable4");
        }
    }
    public int Variable5
    {
        get
        {
            return (int)Refs.GetVariable("Variable5").Value.Value;
        }
        set
        {
            Refs.GetVariable("Variable5").SetValue(value);
        }
    }
    public IUAVariable Variable5Variable
    {
        get
        {
            return (IUAVariable)Refs.GetVariable("Variable5");
        }
    }
#endregion
}
