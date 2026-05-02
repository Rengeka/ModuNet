namespace ModuNetWebApp.Weather.Domain.Entities
{
    public class Summary
    {
        private static readonly string[] detailsList =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        public string Details { get; init; }

        public Summary()
        {
            var random = Random.Shared.Next(detailsList.Length);
            Details = detailsList[random];
        }
    }
}