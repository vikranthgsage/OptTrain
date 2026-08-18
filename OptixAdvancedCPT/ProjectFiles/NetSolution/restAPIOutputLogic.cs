#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using UAManagedCore;
using FTOptix.MQTTBroker;
using FTOptix.AuditSigning;
using FTOptix.EventLogger;
using FTOptix.Report;
using FTOptix.RAEtherNetIP;
using FTOptix.CommunicationDriver;
using FTOptix.Alarm;
#endregion

public class restAPIOutputLogic : BaseNetLogic
{
    IUAVariable inputJSON;

    public override void Start()
    {

        inputJSON = Owner.GetVariable("inputJSONFormat");
        inputJSON.VariableChange += InputJSON_VariableChange;

    }

    private void InputJSON_VariableChange(object sender, VariableChangeEventArgs e)
    {
        updateContent();
    }

    public override void Stop()
    {
        inputJSON.VariableChange -= InputJSON_VariableChange;

    }

    private void updateContent()
    {

        IUAObject tileLocation = Owner.GetObject("HL");

        tileLocation.GetNodesByType<restAPITile>().ToList().ForEach(tileLocation.Remove);

        string jsonStringToConvert = inputJSON.Value;
        JsonDocument doc = JsonDocument.Parse(jsonStringToConvert);
        JsonElement root = doc.RootElement;

        if(root.ValueKind == JsonValueKind.Array)
        {
            foreach(JsonElement jsonPhone in root.EnumerateArray())
            {
                var (phoneObject, phoneAdded) = createPhoneObject(jsonPhone);

                if(phoneAdded)
                {
                    restAPITile newTile = InformationModel.Make<restAPITile>("restAPITile" + phoneObject.Id);
                    newTile.Add(phoneObject);
                    tileLocation.Add(newTile);
                }
            }
        }
        else
        {
            if(root.ValueKind == JsonValueKind.Object)
            {
                var (phoneObject, phoneAdded) = createPhoneObject(root);

                if(phoneAdded)
                {
                    restAPITile newTile = InformationModel.Make<restAPITile>("restAPITile" + phoneObject.Id);
                    newTile.Add(phoneObject);
                    tileLocation.Add(newTile);
                }

            }


        }

    }

    private (restAPIphoneObject phone, bool phoneAdded) createPhoneObject(JsonElement inputJSON)
    {
        try
        {

            bool hasId = inputJSON.TryGetProperty("id", out var idProp);
            bool hasName = inputJSON.TryGetProperty("name", out var nameProp);


            if(!hasId || !hasName)
            {
                return (null, false);
            }


            JsonElement dataProp;
            bool hasData = inputJSON.TryGetProperty("data", out dataProp) && dataProp.ValueKind != JsonValueKind.Null;


            restAPIphoneObject phone = InformationModel.Make<restAPIphoneObject>("restAPIphone");

            phone.Id = "ID: " + idProp.GetString();
            phone.Name = "Name: " + nameProp.GetString();

            if(hasData)
            {
                string[] tempData = new string[phone.Data.Length];
                int count = 0;

                foreach(JsonProperty property in dataProp.EnumerateObject())
                {
                    // Format: "propertyName: propertyValue"
                    tempData[count] = $"{property.Name}: {property.Value.GetRawText()}";
                    count++;
                    if(count == 10) // Limit to 10 elements
                        break;
                }

                phone.Data = tempData;

            }
            return (phone, true);
        }
        catch(Exception ex)
        {
            Log.Info("createPhoneObject", $"Error creating phone object: {ex.Message}");
            return (null, false);
        }


    }


}

public class PhoneRestAPI
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public string Capacity { get; set; }
    public string Price { get; set; }
    public string OtherInfo { get; set; }
}
