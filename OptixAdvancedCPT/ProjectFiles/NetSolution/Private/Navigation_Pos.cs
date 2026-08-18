using System;
using UAManagedCore;

//-------------------------------------------
// WARNING: AUTO-GENERATED CODE, DO NOT EDIT!
//-------------------------------------------

[MapType(NamespaceUri = "OptixAdvancedCPT", Guid = "0546cbc235a13743576da02133a32566")]
public class Navigation_Pos : UAObject
{
#region Children properties
    //-------------------------------------------
    // WARNING: AUTO-GENERATED CODE, DO NOT EDIT!
    //-------------------------------------------
    public string name
    {
        get
        {
            return (string)Refs.GetVariable("name").Value.Value;
        }
        set
        {
            Refs.GetVariable("name").SetValue(value);
        }
    }
    public IUAVariable nameVariable
    {
        get
        {
            return (IUAVariable)Refs.GetVariable("name");
        }
    }
    public string description
    {
        get
        {
            return (string)Refs.GetVariable("description").Value.Value;
        }
        set
        {
            Refs.GetVariable("description").SetValue(value);
        }
    }
    public IUAVariable descriptionVariable
    {
        get
        {
            return (IUAVariable)Refs.GetVariable("description");
        }
    }
    public UAManagedCore.NodeId panelNodeId
    {
        get
        {
            return (UAManagedCore.NodeId)Refs.GetVariable("panelNodeId").Value.Value;
        }
        set
        {
            Refs.GetVariable("panelNodeId").SetValue(value);
        }
    }
    public IUAVariable panelNodeIdVariable
    {
        get
        {
            return (IUAVariable)Refs.GetVariable("panelNodeId");
        }
    }
    public FTOptix.Core.ResourceUri iconPath
    {
        get
        {
            return new FTOptix.Core.ResourceUri(Refs.GetVariable("iconPath").Value);
        }
        set
        {
            Refs.GetVariable("iconPath").SetValue((string)value);
        }
    }
    public IUAVariable iconPathVariable
    {
        get
        {
            return (IUAVariable)Refs.GetVariable("iconPath");
        }
    }
#endregion
}
