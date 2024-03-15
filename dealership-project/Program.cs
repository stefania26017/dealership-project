using dealership_project.Masini;

internal class Program
{
    private static void Main(string[] args)
    {
        Dealership dealership = new Dealership();
        dealership.AddCar(new Masina(1, "Dacia", "Logan", 2000));
        dealership.SaveToFile();
    }
}