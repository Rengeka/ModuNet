namespace ModuNet.AspNet.Rest.Attributes
{
    /// <summary>
    /// Marks a class as an API endpoint group and defines its base route.
    /// </summary>
    /// <remarks>
    /// Classes with this attribute are automatically discovered
    /// by <see cref="EndpointRouteBuilderExtensions.MapEndpointGroups"/> 
    /// and mapped to the routing system.
    /// Classes marked by this attribute must implement <see cref="IEndpointGroup">
    /// </remarks>
    public class ApiEndpointGroupAttribute(string route) : Attribute
    {
        /// <summary>
        /// Gets or sets the base route for the endpoint group.
        /// </summary>
        public string Route { get; set; } = route;
    }
}