#region Using directives
using System;
using System.Linq;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.Store;
using UAManagedCore;
using FTOptix.MQTTBroker;
using FTOptix.AuditSigning;
using FTOptix.EventLogger;
using FTOptix.Report;
using FTOptix.RAEtherNetIP;
using FTOptix.CommunicationDriver;
using FTOptix.Alarm;
#endregion

public class MQTT_ChatBoxLogic : BaseNetLogic
{

    Int64 lastReadedId = -1;
    private PeriodicTask myPeriodicTask;

    public override void Start()
    {
        myPeriodicTask = new PeriodicTask(readSQLData, 1000, LogicObject);
        myPeriodicTask.Start();

        // Insert code to be executed when the user-defined logic is started
    }

    public override void Stop()
    {
        myPeriodicTask?.Dispose();
        // Insert code to be executed when the user-defined logic is stopped
    }

    [ExportMethod]
    public void readSQLData()
    {
        var userName = Owner.GetVariable("userName").Value;
        int numberOfRowsInChat = 12;
        var myStore = Project.Current.Get<Store>("DataStores/EmbeddedDatabase");
        Object[,] ResultSet;
        String[] Header;
        myStore.Query($"SELECT * FROM Lesson10DataLogger WHERE Id > {lastReadedId} ORDER BY Id DESC LIMIT {numberOfRowsInChat}", out Header, out ResultSet);

        var location = Owner.Get("SV/VL");

        int rows = ResultSet.GetLength(0);
        if(rows > 0)
        {

            int userNameIndex = Array.IndexOf(Header, "userName");
            int messageIndex = Array.IndexOf(Header, "Message");
            int idIndex = Array.IndexOf(Header, "Id");
            int timestampIndex = Array.IndexOf(Header, "messageTimestamp");

            for(int i = rows - 1; i >= 0; i--)
            {
                var id = (Int64)ResultSet[i, idIndex];
                var newChatMessage = InformationModel.Make<MQTT_MessageBox>("box" + id);

                newChatMessage.GetVariable("Message").Value = ResultSet[i, messageIndex]?.ToString();
                newChatMessage.GetVariable("UserName").Value = ResultSet[i, userNameIndex]?.ToString();
                newChatMessage.GetVariable("timestamp").Value = ResultSet[i, timestampIndex]?.ToString();
                newChatMessage.GetVariable("messageID").Value = id;

                if(ResultSet[i, userNameIndex]?.ToString() == userName)
                {
                    newChatMessage.GetVariable("isSelfSent").Value = true;
                }

                location.Add(newChatMessage);

                if(location.Children.Count > numberOfRowsInChat)
                {
                    location.Children.First().Delete();
                }
            }

            lastReadedId = (Int64)ResultSet[0, idIndex];

        }



    }




}
