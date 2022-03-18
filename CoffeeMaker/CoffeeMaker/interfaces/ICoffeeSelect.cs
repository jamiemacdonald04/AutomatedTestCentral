/// <summary>
/// This is our contract for our coffee select method and will be what we use to mock.
/// </summary>
namespace CoffeeMaker
{
    public interface ICoffeeSelect
    {
        bool GrindBeans();

        int GetBeans();
    }
}
