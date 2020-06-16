namespace ConfigurationOptions.Configurations
{
    public class APIConfigurations
    {
        public const string Section = "ExternalAPI";

        public string Endpoint { get; set; }
        public int TimeoutInSeconds { get; set; }
    }
}
