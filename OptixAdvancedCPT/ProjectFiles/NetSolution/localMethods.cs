#region Using directives
using System;
using FTOptix.NetLogic;
using UAManagedCore;
using FTOptix.MQTTBroker;
using FTOptix.AuditSigning;
using FTOptix.EventLogger;
using FTOptix.Report;
using FTOptix.RAEtherNetIP;
using FTOptix.CommunicationDriver;
#endregion

public class localMethods : BaseNetLogic
{

    DateTime timeHolder;
    bool isRunning;
    IUAVariable scoreLabel;

    public override void Start()
    {
        isRunning = false;
        scoreLabel = LogicObject.GetVariable("scoreLabel");
        scoreLabel.Value = "Press START!";

        // Insert code to be executed when the user-defined logic is started
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }
    [ExportMethod]
    public void StartCounter()
    {
        if(isRunning) scoreLabel.Value = "Already running! Press STOP.";
        else
        {
            timeHolder = DateTime.Now;
            scoreLabel.Value = "Counting... Press STOP!";
            isRunning = true;
        }
    }
    [ExportMethod]
    public void StopCounter()
    {
        if(isRunning)
        {
            scoreLabel.Value = "Time: " + ((DateTime.Now - timeHolder).TotalMilliseconds).ToString("0") + " ms";
            isRunning = false;
        }

        else
        {
            scoreLabel.Value = "Press START first!";
        }

    }
    [ExportMethod]
    public void ResetCounter()
    {
        isRunning = false;
        scoreLabel.Value = "Press START!";
    }
}
