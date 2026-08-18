#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.OPCUAClient;
using FTOptix.OPCUAServer;
using FTOptix.Retentivity;
using FTOptix.Core;
using FTOptix.CoreBase;
using FTOptix.NetLogic;
using FTOptix.RAEtherNetIP;
using FTOptix.CommunicationDriver;
using FTOptix.DataLogger;
using FTOptix.System;
using FTOptix.AuditSigning;
using FTOptix.EventLogger;
using FTOptix.Report;
#endregion

[CustomBehavior]
public class OPC_UA_MethodTestBehavior : BaseNetBehavior
{
    [ExportMethod]
    public override void Start()
    {
        // Insert code to be executed when the user-defined behavior is started
        Project.Current.GetVariable("Model/Lesson 11/Tags/Variable1").Value += 1;
    }

    [ExportMethod]
    public void AddTags(int tag1, int tag2, out string result, out int tag3)
    {
        tag3 = tag2 + tag1;
        if (tag3 < 77) result = "Low Value";
        else result = "Good Value";

        Project.Current.GetVariable("Model/Lesson 11/Tags/Variable4").Value += 1;
    }

    [ExportMethod]
    public override void Stop()
    {
        // Insert code to be executed when the user-defined behavior is stopped
    }

    #region Auto-generated code, do not edit!
    protected new OPC_UA_MethodTest Node => (OPC_UA_MethodTest)base.Node;
    #endregion
}
