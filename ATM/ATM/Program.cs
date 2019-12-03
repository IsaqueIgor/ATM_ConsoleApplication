
namespace ATM
{
    class Program
    {
        static void Main()
        {
            DisplayMenu Display = new DisplayMenu();

            DataBase.Init();

            Display.DisplayMenuOptions();

        }
    }
}
