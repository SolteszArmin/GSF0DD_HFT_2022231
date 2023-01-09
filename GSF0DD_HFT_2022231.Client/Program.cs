using ConsoleTools;
using GSF0DD_HFT_2022231.Models;
using System;
using System.Collections.Generic;

namespace GSF0DD_HFT_2022231.Client
{
    public class Program
    {
        static RestService rest;

        static void List(string entity)
        {
            if (entity == "Game")
            {
                List<Game> proce = rest.Get<Game>("game");
                Console.WriteLine("ID \t Name \t Release Date");
                foreach (var item in proce)
                {
                    Console.WriteLine(item.GameId + "\t" + item.Name + "\t" + item.ReleaseDate);
                }
            }
            if (entity == "Publisher")
            {
                List<Publisher> chip = rest.Get<Publisher>("publisher");
                foreach (var item in chip)
                {
                    Console.WriteLine(item.PublisherId + "\t" + item.Name);
                }
            }
            if (entity == "Genre")
            {
                List<Genre> brand = rest.Get<Genre>("genre");
                foreach (var item in brand)
                {
                    Console.WriteLine(item.GenreId + "\t" + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Create(string entity)
        {
            if (entity == "Game")
            {
                Console.Write("Enter Game Name:");
                string name = Console.ReadLine();
                Console.Write("Enter Game ReleaseDate (yyyy-mm-dd):");
                DateTime releaseDate = DateTime.Parse(Console.ReadLine());
                rest.Post(new Game() { Name = name, ReleaseDate = releaseDate }, "game");

            }
            if (entity == "Publisher")
            {
                Console.Write("Enter Publisher's Name:");
                string name = Console.ReadLine();
                rest.Post(new Publisher() { Name = name }, "publisher");

            }
            if (entity == "Genre")
            {
                Console.Write("Enter a new Genre:");
                string name = Console.ReadLine();
                rest.Post(new Genre() { Name = name }, "genre");

            }
        }
        static void Update(string entity)
        {
            if (entity == "Game")
            {
                Console.Write("Enter Game id to update:");
                int id = int.Parse(Console.ReadLine());
                Game first = rest.Get<Game>(id, "game");
                Console.Write($"New name [old: {first.Name}]: ");
                string name = Console.ReadLine();
                first.Name = name;
                rest.Put(first, "game");
            }
            if (entity == "Publisher")
            {
                Console.Write("Enter Publisher's id to update:");
                int id = int.Parse(Console.ReadLine());
                Publisher first = rest.Get<Publisher>(id, "publisher");
                Console.Write($"New name [old: {first.Name}]: ");
                string name = Console.ReadLine();
                first.Name = name;
                rest.Put(first, "publisher");
            }
            if (entity == "Genre")
            {
                Console.Write("Enter Genre's id to update:");
                int id = int.Parse(Console.ReadLine());
                Genre first = rest.Get<Genre>(id, "genre");
                Console.Write($"New name [old: {first.Name}]: ");
                string name = Console.ReadLine();
                first.Name = name;
                rest.Put(first, "genre");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Game")
            {
                Console.WriteLine("Enter Game id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "game");
            }
            if (entity == "Publisher")
            {
                Console.WriteLine("Enter Publisher's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "publisher");
            }
            if (entity == "Genre")
            {
                Console.WriteLine("Enter Genre's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "genre");
            }
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:25922/", "game");


            var GameSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Game"))
                .Add("Create", () => Create("Game"))
                .Add("Delete", () => Delete("Game"))
                .Add("Update", () => Update("Game"))
                .Add("Exit", ConsoleMenu.Close);

            var PublisherSubMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Publisher"))
                .Add("Create", () => Create("Publisher"))
                .Add("Delete", () => Delete("Publisher"))
                .Add("Update", () => Update("Publisher"))
                .Add("Exit", ConsoleMenu.Close);

            var GenreSubMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => List("Genre"))
                .Add("Create", () => Create("Genre"))
                .Add("Delete", () => Delete("Genre"))
                .Add("Update", () => Update("Genre"))
                .Add("Exit", ConsoleMenu.Close);
            var DataStatisticsSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List all Games with action Genre", () => q1())
                .Add("List Activision Games", () => q2())
                .Add("List all games with open world genre created by From Software", () => q3())
                .Add("List all games published by From Software", () => q4())
                .Add("List all games released between 2012 and 2022 by From Software", () => q5())
                .Add("Exit", ConsoleMenu.Close);
            var menu = new ConsoleMenu(args, level: 0)
                .Add("Game", () => GameSubMenu.Show())
                .Add("Publisher", () => PublisherSubMenu.Show())
                .Add("Genre", () => GenreSubMenu.Show())
                .Add("Data Statistics", () => DataStatisticsSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
        static void q1()
        {
            Console.WriteLine("List all Games with action Genre");
            List<Game> pro = rest.Get<Game>("Statistics/GamesWithActionGenre");
            foreach (var item in pro)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        static void q2()
        {
            Console.WriteLine("List Activision Games");
            List<Game> pro = rest.Get<Game>("Statistics/ActivisionGames");
            foreach (var item in pro)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        static void q3()
        {
            Console.WriteLine("List all games with open world genre created by From Software");
            List<Game> pro = rest.Get<Game>("Statistics/GamesWithOpenWorldgenrereleasedByFromSoftware");
            foreach (var item in pro)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        static void q4()
        {
            Console.WriteLine("List all games published by From Software");
            List<Game> pro = rest.Get<Game>("Statistics/GamesPublishedByFromSoftware");
            foreach (var item in pro)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        static void q5()
        {
            Console.WriteLine("List all games released between 2012 and 2022 by From Software");
            List<Game> pro = rest.Get<Game>("Statistics/GamesReleasedBetween2012And2022ByFromSoftware");
            foreach (var item in pro)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
    }
}
