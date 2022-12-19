namespace MagicVillaWebAPI.Logging
{
    public interface ILogging
    {
        public void Log(string message, string type)
        {
            if (type == "error")
            {
                Console.Write("ERROR - " + message);
            }
            else
            {
                Console.WriteLine(message);
            }
        }

    }
}
