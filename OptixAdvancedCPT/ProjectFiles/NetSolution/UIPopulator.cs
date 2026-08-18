using System.Linq;
using FTOptix.HMIProject;
using FTOptix.UI;
using UAManagedCore;
using FTOptix.MQTTBroker;
using FTOptix.AuditSigning;
using FTOptix.EventLogger;
using FTOptix.Report;
using FTOptix.RAEtherNetIP;
using FTOptix.CommunicationDriver;
using FTOptix.Alarm;
using OpcUa = UAManagedCore.OpcUa;

public class UIPopulator : FTOptix.NetLogic.BaseNetLogic
{


    public override void Start()
    {
        // Get the Model variable of the ListBox
        modelObjectVariable = LogicObject.Get<IUAVariable>("ModelObject");
        // Subscribe to the VariableChange event
        modelObjectVariable.VariableChange += ModelObjectVariable_VariableChange;
        // Build the UI based on the selected item
        BuildUI(modelObjectVariable.Value);
    }

    private void ModelObjectVariable_VariableChange(object sender, VariableChangeEventArgs e)
    {
        // Every time the ModelObject variable changes, rebuild the UI
        BuildUI(e.NewValue);
        Log.Info(LogicObject.BrowseName, "New LogicObject Selected");

    }

    public override void Stop()
    {
        // Destroy the variable change event
        modelObjectVariable.VariableChange -= ModelObjectVariable_VariableChange;
    }

    private void BuildUI(NodeId modelObjectNodeId)
    {
        // Get the VerticalContainer that will hold the UI elements
        var verticalContainer = (RowLayout)Owner;
        // Get the ModelObject of the VerticalLayout from the NodeId
        var modelObject = InformationModel.Get(modelObjectNodeId);

        // Clear all the children of the VerticalContainer
        foreach(var child in verticalContainer.Children.OfType<Item>())
        {
            child.Delete();
        }

        // Create the UI elements based on the DataType of the children of the ModelObject
        foreach(var objectProperty in modelObject.Children.OfType<IUAVariable>())
        {
            Item uiObject;

            if(objectProperty.DataType == OpcUa.DataTypes.Boolean)
                uiObject = MakeSwitch(objectProperty);
            else if(objectProperty.DataType == OpcUa.DataTypes.String)
                uiObject = MakeTextBox(objectProperty);
            else if(objectProperty.DataType == OpcUa.DataTypes.Int32)
                uiObject = MakeLinearGauge(objectProperty);
            else if(objectProperty.DataType == OpcUa.DataTypes.Float)
                uiObject = MakeCircularGauge(objectProperty);
            else if(objectProperty.DataType == FTOptix.Core.DataTypes.ResourceUri)
                uiObject = MakeImage(objectProperty);
            else
                uiObject = MakeTextBox(objectProperty);

            // Add the UI element to the VerticalContainer
            if(uiObject != null)
                verticalContainer.Add(uiObject);
        }
    }

    private static propertiesTile MakeBaseContainer(IUAVariable variable)
    {
        // Create a Panel to hold the UI element
        var container = InformationModel.MakeObject<propertiesTile>("ControlContainer");
        // Create a Label to show the name of the variable
        var label = InformationModel.MakeObject<Label>("Label");
        label.LeftMargin = 10;
        label.TopMargin = 10;
        label.Text = variable.BrowseName;
        label.FontWeight = FontWeight.Bold;
        // Add the Label to the Panel
        container.Add(label);
        return container;
    }

    private static Item MakeSwitch(IUAVariable variable)
    {
        // Create a base container
        var container = MakeBaseContainer(variable);
        var mySwitch = InformationModel.MakeObject<Switch>("Switch");
        mySwitch.HorizontalAlignment = HorizontalAlignment.Center;
        mySwitch.VerticalAlignment = VerticalAlignment.Center;
        mySwitch.RightMargin = 40;
        // Bind the Checked property of the Switch to the variable
        MakeDataBind(mySwitch.Children.Get<IUAVariable>("Checked"), variable);
        // Add the Switch to the container
        container.Add(mySwitch);
        return container;
    }

    private static Item MakeTextBox(IUAVariable variable)
    {
        // Create a base container
        var container = MakeBaseContainer(variable);
        var textBox = InformationModel.MakeObject<TextBox>("TextBox");
        textBox.HorizontalAlignment = HorizontalAlignment.Center;
        textBox.VerticalAlignment = VerticalAlignment.Center;
        textBox.RightMargin = 40;
        // Bind the Text property of the TextBox to the variable
        MakeDataBind(textBox.Children.Get<IUAVariable>("Text"), variable);
        // Add the TextBox to the container
        container.Add(textBox);
        return container;
    }

    private static Item MakeCircularGauge(IUAVariable variable)
    {
        // Create a base container
        var container = MakeBaseContainer(variable);
        // Create a CircularGauge
        var circularGauge = InformationModel.MakeObject<CircularGauge>("CircularGauge");
        circularGauge.Width = 140;
        circularGauge.HorizontalAlignment = HorizontalAlignment.Center;
        circularGauge.VerticalAlignment = VerticalAlignment.Stretch;
        circularGauge.RightMargin = 40;
        circularGauge.TopMargin = 20;
        // Bind the Value property of the CircularGauge to the variable
        MakeDataBind(circularGauge.Children.Get<IUAVariable>("Value"), variable);
        // Add the CircularGauge to the container
        container.Add(circularGauge);
        return container;
    }

    private static Item MakeLinearGauge(IUAVariable variable)
    {
        // Create a base container
        var container = MakeBaseContainer(variable);
        // Create a LinearGauge
        var linearGauge = InformationModel.MakeObject<LinearGauge>("LinearGauge");
        linearGauge.Width = 250;
        linearGauge.Height = 50;
        linearGauge.HorizontalAlignment = HorizontalAlignment.Center;
        linearGauge.VerticalAlignment = VerticalAlignment.Center;
        linearGauge.RightMargin = 40;
        linearGauge.TopMargin = 20;
        // Bind the Value property of the LinearGauge to the variable
        MakeDataBind(linearGauge.Children.Get<IUAVariable>("Value"), variable);
        // Add the LinearGauge to the container
        container.Add(linearGauge);
        return container;
    }

    private static Item MakeImage(IUAVariable variable)
    {
        // Create the image object
        var image = InformationModel.MakeObject<Image>("Image");
        image.HorizontalAlignment = HorizontalAlignment.Center;
        image.Width = 100;
        image.Height = 100;
        image.TopMargin = 20;
        image.BottomMargin = 20;
        // Set the path property of the image object
        image.Path = new FTOptix.Core.ResourceUri(variable.Value);
        return image;
    }

    private static void MakeDataBind(IUAVariable property, IUAVariable targetVariable)
    {
        // Set the DynamicLink to a variable as ReadWrite
        property.SetDynamicLink(targetVariable, FTOptix.CoreBase.DynamicLinkMode.ReadWrite);
    }

    private IUAVariable modelObjectVariable;
}
