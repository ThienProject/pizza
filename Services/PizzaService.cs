namespace Pizza.Services;
using Pizza.Models;
public static class PizzaService
{
    static List<Pizza> pizzas { get; }
    static int nextId = 3;

    static PizzaService()
    {
        pizzas = new List<Pizza> {
            new Pizza { Id = 1, Name ="pizza 1", IsGlutenFree = false, Price =12},
            new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true,  Price =12 }
        };
    }

    public static List<Pizza> GetAll() => pizzas;

    public static Pizza? Get(int id) => pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        pizzas.Add(pizza);
    }

    public static bool Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null)
            return false;
        pizzas.Remove(pizza);
        return true;
    }

    public static bool Update(Pizza pizza)
    {
        var index = pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return false;
        pizzas[index] = pizza;
        return true;
    }
}