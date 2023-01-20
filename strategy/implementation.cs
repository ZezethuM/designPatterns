namespace Strategy
{
    //strategy
    public interface IExportService
    {
        void Export(Order order);

    }

    //concreteStrategy

    public class JsonExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($" Exporting {order.Name} to Json");
        }
    }
    //concreteStrategy
    public class XMLExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($" Exporting {order.Name} to XML");
        }
    }

    //concreteStrategy

    public class CSVExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($" Exporting {order.Name} to CSV");
        }
    }

    public class Order 
    {
        public string? Customer { get; set; }
        public int Amount { get; set; }
        public string? Name { get;set; }
        public string? Description { get; set;}
        public Order(string customer, int amount, string name)
        {
            Customer = customer;
            Amount = amount;
            Name = name;  
        }
        public void Export(IExportService exportService)
        {
            if(exportService is null)
            {
                throw new ArgumentNullException(nameof(exportService));
            }

            exportService?.Export(this);
        }
        
    }
}