namespace ModuNet.AspNet.Rest.Attributes;

public class ApiEndpointGroupAttribute(string route) : Attribute
{
    public string Route { get; set; } = route;
}