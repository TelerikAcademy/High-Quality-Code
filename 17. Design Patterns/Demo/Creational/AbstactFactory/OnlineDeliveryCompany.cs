namespace AbstractFactory
{
    using AbstractFactory.Factories;
    using AbstractFactory.Pizzas;

    public class OnlineDeliveryCompany
    {
        private readonly PizzaFactory factory;

        public OnlineDeliveryCompany(PizzaFactory pizzaFactory)
        {
            this.factory = pizzaFactory;
        }

        public CheesePizza DeliverCheesePizza()
        {
            return this.factory.MakeCheesePizza();
        }

        public Calzone DeliverCalzone()
        {
            return this.factory.MakeCalzone();
        }

        public PepperoniPizza DeliverPepperoniPizza()
        {
            return this.factory.MakePepperoniPizza();
        }
    }
}
