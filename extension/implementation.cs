namespace PizzaExtension
{
    public interface IPizza
    {
        string MakePizza();
    }
    public class Pizza : IPizza
    {
        public string MakePizza()
        {
            return "Plain Pizza";
        }
    }
    static class PizzaExtensioning
    {
        public static string AddingFlavour(this Pizza pizza)
        {
            return pizza.MakePizza() + " Added Chicken & Mushrooms";
        }

    }
}