namespace dealership_project.Masini
{
    public class Masina
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Model { get; set; }
        public int An { get; set; }

        public Masina(int id, string marca, string model, int an) 
        {
            Id = id;
            Marca = marca;
            Model = model;
            An = an;
        }

        public Masina(string text)
        {
            string[] values = text.Split("/");

            Id = int.Parse(values[0]);
            Marca = values[1];
            Model = values[2];
            An = int.Parse(values[3]);
        }

        public string ToSaveableText()
        {
            return $"{Id}/{Marca}/{Model}/{An}\n";
        }

        public override string ToString()
        {
            string descriere = "";
            descriere += "Id: " + Id + "\n";
            descriere += "Marca: " + Marca + "\n";
            descriere += "Model: " + Model + "\n";
            descriere += "An : " + An + "\n";
            return descriere;
        }
    }
}
