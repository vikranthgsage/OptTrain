#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.DataLogger;
using FTOptix.HMIProject;
using FTOptix.WebUI;
using FTOptix.NetLogic;
using FTOptix.NativeUI;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.Report;
using FTOptix.MQTTClient;
using FTOptix.RAEtherNetIP;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.Alarm;
using FTOptix.CommunicationDriver;
using FTOptix.AuditSigning;
using FTOptix.EventLogger;
using FTOptix.Core;
#endregion

public class ReadWriteVariables : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    [ ExportMethod ] 
    public void Sum() 
    { 
    var addend1 = ( Int32 ) Project . Current . GetVariable ( "Model/Lesson9/Variable1" ) . Value; 
    var addend2 = ( Int32 ) Project . Current . GetVariable ( "Model/Lesson9/Variable2" ) . Value; 
    Project . Current . GetVariable ( "Model/Lesson9/Variable3" ) . Value = addend1 + addend2; 
    } 

}
