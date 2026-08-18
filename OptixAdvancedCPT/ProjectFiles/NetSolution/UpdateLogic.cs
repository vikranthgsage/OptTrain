#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.DataLogger;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.NativeUI;
using FTOptix.WebUI;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.MQTTClient;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.AuditSigning;
using FTOptix.Core;
using FTOptix.Report;
using FTOptix.RAEtherNetIP;
using FTOptix.CommunicationDriver;
using FTOptix.Alarm;
#endregion

public class UpdateLogic : BaseNetLogic
{
    public override void Start()
    {
        UpdateFields();
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    [ExportMethod]
    public void UpdateFields()
    {

        var selectedRow = InformationModel.Get(LogicObject.GetVariable("selectedItem").Value);

        if (selectedRow != null && selectedRow.GetVariable("ItemName") != null)
        {
            Owner.GetVariable("Item/Text").Value = selectedRow.GetVariable("ItemName").Value;
            Owner.GetVariable("Quantity/Value").Value = selectedRow.GetVariable("Quantity").Value;
            Owner.GetVariable("Category/SelectedValue").Value = selectedRow.GetVariable("Category").Value;
        }




    }
}
