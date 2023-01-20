namespace Singleton
{
    //singleton

    public class Logger 
    {
        //Lazy<T>
        private static readonly Lazy<Logger> _lazyLogger = new Lazy<Logger>(() => new Logger());
        // private static Logger? _instance;

        //intance

        public static Logger Instance
        {
            get
            {
                return _lazyLogger.Value;
                // if(_instance == null)
                // {
                //     _instance = new Logger();
                // }
                // return _instance;
            }
        }
        protected Logger()
        {

        }
        // singletonoperation
        public void Log(string message)
        {
            Console.WriteLine($"Message to log: {message}");
        }
    }
}