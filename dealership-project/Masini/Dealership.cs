namespace dealership_project.Masini
{
    public class Dealership
    {
        public List<Masina> Masini { get; set; }

        public Dealership() {

            LoadFromFile();
        }

        // Public Methods

        public void LoadFromFile()
        {
            string path = "masini.txt";
            StreamReader sr = new StreamReader(path);
            Masini = new List<Masina>();
            while (!sr.EndOfStream)
            {
                string text = sr.ReadLine();
                Masina masina = new Masina(text);
                Masini.Add(masina);
            }
            sr.Close();
        }

        public void SaveToFile()
        {
            string value = "";
            foreach(Masina masina in Masini)
            {
                value += masina.ToSaveableText();
            }

            string path = "masini.txt";
            StreamWriter sw = new StreamWriter(path);
            sw.Write(value);
            sw.Close();
        }

        public void Afisare()
        {
            for(int i=0;i<Masini.Count;i++)
            {
                Console.WriteLine(Masini[i]);
            }
        }

        public void AddCar(Masina masina)
        {
            masina.Id = NewId();
            Masini.Add(masina);
        }

        public Masina FindById(int id)
        {
            for(int i=0;i < Masini.Count;i++)
            {
                if (Masini[i].Id == id) 
                { 
                    return Masini[i];
                }
            }

            return null;
        }

        public void RemoveById(int id)
        {
            Masini.Remove(FindById(id));
        }

        public List<Masina> FindAllByMarca(string marca)
        {
            List<Masina> found = new List<Masina>();
            for(int i=0;i<Masini.Count ;i++)
            {
                if (Masini[i].Marca == marca)
                {
                    found.Add(Masini[i]);
                }
            }
            return found;
        }

        public Masina OldestCar()
        {
            int minim = 4000;
            Masina result = null;

            for (int i = 0; i < Masini.Count; i++)
            {
                if (Masini[i].An < minim) 
                {
                    minim = Masini[i].An;
                    result = Masini[i];
                }
            }

            return result;
        }

        public Masina NewestCar()
        {
            int maxim = 0;
            Masina rezultat = null;
            for(int i=0;i<Masini.Count;i++)
            {
                if (Masini[i].An > maxim)
                {
                    maxim = Masini[i].An;
                    rezultat = Masini[i];
                }
            }
            return rezultat;
        }

        // Private Methods

        private int NewId()
        {
            Random random = new Random();
            int result = random.Next(1, 1000);

            while(FindById(result) != null)
            {
                result = random.Next(1, 1000);
            }

            return result;
        }
    }
}
