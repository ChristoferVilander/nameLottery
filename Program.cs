namespace Julklappspelet
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Skriv antalet deltagare");

            int participants = Convert.ToInt32(Console.ReadLine());

            List<string> peopleList = new List<string> { };

            Console.WriteLine("Skriv namnen");
            int j = 0;
            while (j < participants)
            {
                peopleList.Add(Console.ReadLine());
                j++;
            }

            Random rnd = new Random();
            var shuffled = peopleList.OrderBy(_ => rnd.Next()).ToList();

            Console.WriteLine("Det blir följande uppdelning");
            int i = 0;
            while (i < peopleList.Count)
            {
                Console.Write(shuffled[i] + " gives to ");

                i++;

                if (i == peopleList.Count) { break; }
                Console.WriteLine(shuffled[i]);

            }

            Console.Write(shuffled[0]);
        }
    }
}