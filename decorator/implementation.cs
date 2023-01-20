namespace Decorator
{
    //Component (as Interface)
    public interface IMailService
    {
        bool SendMail(string message);
    }
    //ConcreteComponent1
    public class CloudMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message \"{message}\" " + $"sent via {nameof(CloudMailService)}.");
            return true;
        }
    }
    //ConcreteComponent2
    public class OnPremiseMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message \"{message}\" " + $"sent via {nameof(OnPremiseMailService)}.");
            return true;
        }
    }

    //Decirator

    public class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;
        public MailServiceDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }
        public virtual bool  SendMail(string message)
        {
            return _mailService.SendMail(message);
        }
    }

    //ConcreteDecorator 

    public class StatisticsDecorator : MailServiceDecoratorBase
    {
        public StatisticsDecorator(IMailService mailService) : base(mailService)
        {

        }
        public override bool SendMail(string message)
        {
            //Fake collecting statistics
            Console.WriteLine($"Collecting statistics in {nameof(StatisticsDecorator)}.");
            return base.SendMail(message);
        }
    }

    //ConcreteDecorator2

    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        //A list of sent messages - a "fake dtabase
        public List<string> SentMessages { get; private set;} = new List<string>();
        public MessageDatabaseDecorator(IMailService mailService) : base(mailService)
        {
        }
        public override bool SendMail(string message)
        {
            if(base.SendMail(message))
            {
                //storee sent message
                SentMessages.Add(message);
                return true;
            };
            return false;
        }
    }

}