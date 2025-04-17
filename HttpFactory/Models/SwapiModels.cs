public class SwapiModels
{
    public class SwapiPersonProperties
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Gender { get; set; }
    }

    public class SwapiPersonResult
    {
        public SwapiPersonProperties Properties { get; set; }
    }

    public class SwapiPersonResponse
    {
        public string Message { get; set; }
        public SwapiPersonResult Result { get; set; }
    }
}