namespace SampleApp.Rest;

public class ApiEndpointGroupAttribute(string route) : Attribute
{
    public string Route { get; set; } = route;
}