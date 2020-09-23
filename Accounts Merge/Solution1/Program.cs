using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert count of the rows");
            var rows = int.Parse(Console.ReadLine());
            var accounts = new List<IList<string>>();

            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split(",").ToList();
                accounts.Add(input);
            }

            var result = AccountsMerge(accounts);

            foreach (var row in result)
            {
                Console.WriteLine(string.Join(", ", row));
            }

        }

        public static IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {

            var graph = new Dictionary<string, List<string>>();
            var emailToNameDictionary = new Dictionary<string, string>();

            // creating graph:
            for (var i = 0; i < accounts.Count; i++)
            {
                var name = accounts[i][0];
                var firstEmail = accounts[i][1];
                var emails = accounts[i].Skip(1).ToList();

                foreach (var email in emails)
                {
                    AddEdge(graph, firstEmail, email);
                    AddEdge(graph, email, firstEmail);
                    emailToNameDictionary[email] = name;
                }
            }

            var result = new List<IList<string>>();
            var visited = new HashSet<string>();

            foreach (var kvp in graph)
            {
                var currentSet = new HashSet<string>();
                var key = kvp.Key;

                if (!visited.Contains(key))
                {
                    Dfs(graph, key, ref visited, ref currentSet);
                }

                var name = emailToNameDictionary[key];
                var mergedAccaunt = new List<string>() { name };
                var emails = currentSet.ToList();

                if (emails.Count > 0)
                {
                    emails.Sort(string.CompareOrdinal);
                    mergedAccaunt.AddRange(emails);
                    result.Add(mergedAccaunt);
                }
            }

            return result;
        }

        public static void AddEdge(Dictionary<string, List<string>> graph, string email, string neighbor)
        {
            if (graph.ContainsKey(email))
            {
                graph[email].Add(neighbor);
            }
            else
            {
                graph[email] = new List<string>()
                {
                    neighbor
                };
            }
        }

        public static void Dfs(Dictionary<string, List<string>> graph, string source, ref HashSet<string> visited, ref HashSet<string> currentSet)
        {
            visited.Add(source);
            currentSet.Add(source);

            if (!graph.ContainsKey(source))
            {
                return;
            }


            foreach (var neighbor in graph[source])
            {
                if (!visited.Contains(neighbor))
                {
                    Dfs(graph, neighbor, ref visited, ref currentSet);
                }
            }
        }

    }
}
// test input:
// count = 4
// "John","johnsmith@mail.com","john_newyork@mail.com",
// "John","johnsmith@mail.com","john00@mail.com",
// "Mary","mary@mail.com",
// "John","johnnybravo@mail.com"

// 5
//"Alex","Alex5@m.co","Alex4@m.co","Alex0@m.co"
//"Ethan","Ethan3@m.co","Ethan3@m.co","Ethan0@m.co"
//"Kevin","Kevin4@m.co","Kevin2@m.co","Kevin2@m.co"
//"Gabe","Gabe0@m.co","Gabe3@m.co","Gabe2@m.co"
//"Gabe","Gabe3@m.co","Gabe4@m.co","Gabe2@m.co"
//