using System;
using System.Collections.Generic;
using System.Linq;

namespace Julklappspelet
{
    class Program
    {
        static void Main(string[] args)
        {
            int participantCount = ReadParticipantCount();
            List<string> participantNames = ReadParticipantNames(participantCount);

            List<(string Giver, string Receiver)> assignments = CreateCyclicAssignments(participantNames);

            Console.WriteLine();
            Console.WriteLine("Det blir följande uppdelning:");
            PrintAssignments(assignments);
        }

        private static int ReadParticipantCount()
        {
            while (true)
            {
                Console.Write("Skriv antalet deltagare (minst 2): ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int count) && count >= 2)
                {
                    return count;
                }

                Console.WriteLine("Ogiltigt antal. Försök igen.");
            }
        }

        private static List<string> ReadParticipantNames(int count)
        {
            var names = new List<string>(capacity: count);
            Console.WriteLine("Skriv namnen, ett per rad:");

            while (names.Count < count)
            {
                Console.Write($"{names.Count + 1}/{count}: ");
                string? name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Namnet får inte vara tomt. Försök igen.");
                    continue;
                }

                names.Add(name.Trim());
            }

            return names;
        }

        private static List<(string Giver, string Receiver)> CreateCyclicAssignments(IReadOnlyList<string> names)
        {
            var random = new Random();
            List<string> shuffled = names.OrderBy(_ => random.Next()).ToList();

            int n = shuffled.Count;
            var pairs = new List<(string Giver, string Receiver)>(capacity: n);

            for (int i = 0; i < n; i++)
            {
                string giver = shuffled[i];
                string receiver = shuffled[(i + 1) % n]; // sista ger till första
                pairs.Add((giver, receiver));
            }

            return pairs;
        }

        private static void PrintAssignments(IEnumerable<(string Giver, string Receiver)> assignments)
        {
            foreach (var (giver, receiver) in assignments)
            {
                Console.WriteLine($"{giver} ger till {receiver}");
            }
        }
    }
}