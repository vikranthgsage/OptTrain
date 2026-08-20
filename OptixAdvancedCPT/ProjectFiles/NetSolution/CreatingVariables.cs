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
using FTOptix.OPCUAServer;
#endregion


public class CreatingVariables : BaseNetLogic 
{ 
    [ExportMethod] 
    public void CreateVariables() 
    { 
        var myFolder = Project.Current.Get<Folder>("Model/Lesson9"); 
        foreach ( var item in myFolder . Children) 
        { 
            item.Delete(); 
        } 
 
        for ( int i = 1; i <= 3; i ++ ) 
        { 
            var myVar = InformationModel . MakeVariable ("Variable" + i , 
                OpcUa.DataTypes.Int32); 
            myFolder.Add(myVar); 
        } 
    } 
} 
