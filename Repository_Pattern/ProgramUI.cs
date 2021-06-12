using RepositoryPattern_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Pattern
{
    public class ProgramUI
    {
        bool _isRunning = true;
        //newing up the StreamingContentRepository Class so I can get CRUD methods
        private readonly StreamingContentRepository _repo = new StreamingContentRepository();

       public void Start()
        {
            //seed data into our app
            SeedContentList();
            //Run menu method
            RunMenu();
        }

        public void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }

  

        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Streaming Content Management System\n" +
                "Select Menu Item:\n" +
                "1. Show All Streaming Content\n" +
                "2. Find Streaming Content by title\n" +
                "3. Add New Streaming Content\n" +
                "4. Update Existing Content Description\n" +
                "5. Remove Streaming Content\n" +
                "6. Exit\n");
            string userInput = Console.ReadLine();
            return userInput;
        }

        public void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    //show all content
                    DisplayAllContent();
                    break;
                case "2":
                    //display content by title
                    DisplayContentByTitle();
                    break;
                case "3":
                    //add new content
                    CreateNewContent();
                    break;
                case "4":
                    //update content description
                    UpdateContentDescription();
                    break;
                case "5":
                    //Remove content
                    DeleteContent();
                    break;
                case "6":
                    //exit
                    _isRunning = false;
                    return;
                default:
                    Console.WriteLine("Invalid Selection. Press any key to return to main menu.");
                    GetMenuSelection();
                    return;
                
            }
        }

        private void DisplayAllContent()
        {
            List<StreamingContent> listOfContent = _repo.GetAllStreamingContent();
            foreach (StreamingContent content in listOfContent)
            {
                DisplayContent(content);
            }
                PressAnyKeyToReturnToMainMenu();

            
        }

        private void DisplayContentByTitle()
        {
            Console.Write("Enter a title: ");
            string title = Console.ReadLine();

            StreamingContent content = _repo.GetContentByTitle(title);

            if(content != null)
            {
                DisplayContent(content);
                PressAnyKeyToReturnToMainMenu();
            }
            else
            {
                Console.WriteLine("Invalid Selection. Press any key to return to main menu.");
                Console.ReadKey();
                GetMenuSelection();
                return;
            }
        }

        private void DisplayContent(StreamingContent content)
        {
            Console.WriteLine($"Title: {content.Title}\n" +
                 $"Description:{content.Description}\n" +
                 $"Release Year:{content.ReleaseYear}\n" +
                 $"Genre: {content.Genre}\n" +
                 $"Stars: {content.StarRating}\n" +
                 $"Maturity Rating: {content.AgeRating}\n");
        }

        private void CreateNewContent()
        {
            Console.Clear();
            Console.WriteLine("Enter a title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter a description:");
            string description = Console.ReadLine();

            Console.WriteLine("Enter the release year: ");
            int releaseYear = int.Parse(Console.ReadLine());

            GenreType genre = GetGenreType();

            Console.WriteLine("Enter a Star Rating: ");
            double starRating = double.Parse(Console.ReadLine());

            MaturityRating ageRating = GetAgeRating();

            StreamingContent content = new StreamingContent(title, description, ageRating, starRating, releaseYear, genre);

            _repo.AddContentToDirectory(content);

            PressAnyKeyToReturnToMainMenu();
        }

        private GenreType GetGenreType()
        {
            Console.WriteLine("Select a Genre:\n" +
                            "1. Thriller\n" +
                            "2. Scifi\n" +
                            "3. Action\n" +
                            "4. Drama\n" +
                            "5. Horror\n" +
                            "6. Mystery\n" +
                            "7. Romance\n" +
                            "8. RomCom\n" +
                            "9. Comedy\n" +
                            "10. Documentary\n" +
                            "11. Western\n");
           while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        return GenreType.Thriller;
                    case "2":
                        return GenreType.SciFi;
                    case "3":
                        return GenreType.Action;
                    case "4":
                        return GenreType.Drama;
                    case "5":
                        return GenreType.Horror;
                    case "6":
                        return GenreType.Mystery;
                    case "7":
                        return GenreType.Romance;
                    case "8":
                        return GenreType.RomCom;
                    case "9":
                        return GenreType.Comedy;
                    case "10":
                        return GenreType.Documentary;
                    case "11": 
                        return GenreType.Western;
                    
                }
            }
        }
        private void UpdateContentDescription()
        {
            Console.WriteLine("Enter title of content to be edited: ");
            string title = Console.ReadLine();
            if(_repo.GetContentByTitle(title) != null)
            {
                Console.WriteLine("Enter a new description: ");
                string description = Console.ReadLine();
                _repo.UpdateStreamingContentDescription(title, description);
            }
            else
            {
                Console.WriteLine("Invalid Selection. Press any key to return to main menu.");
                PressAnyKeyToReturnToMainMenu();
                Console.ReadKey();
            }

            

            
        }
        private MaturityRating GetAgeRating()
        {
            Console.WriteLine("Select a Genre:\n" +
                           "1. G\n" +
                           "2. PG\n" +
                           "3. PG-13\n" +
                           "4. R\n" +
                           "5. NC-17\n");
                           
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        return MaturityRating.G;
                    case "2":
                        return MaturityRating.PG;
                    case "3":
                        return MaturityRating.PG-13;
                    case "4":
                        return MaturityRating.R;
                    case "5":
                        return MaturityRating.NC17;


                }
            }
        }

        private void DeleteContent()
        {
            Console.WriteLine("Enter title to be deleted");

            string title = Console.ReadLine();
            if(_repo.GetContentByTitle(title) != null)
            {
                _repo.DeleteContentByTitle(title);
            }
            else
            {
                Console.WriteLine("Invalid Selection. Press any key to return to main menu.");
                PressAnyKeyToReturnToMainMenu();
                Console.ReadKey();
            }

        }
        public void PressAnyKeyToReturnToMainMenu()
        {
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();
            RunMenu();
        }
        //seed content

        private void SeedContentList()
        { 

               
            
                StreamingContent jaws = new StreamingContent("Jaws", "Scary shark movie", MaturityRating.PG, 8.0, 1975, GenreType.Thriller);
                StreamingContent dieHard = new StreamingContent("Die Hard", "The best Die Hard movie", MaturityRating.R, 8.2, 1988, GenreType.Action);
                StreamingContent silenceOfLambs = new StreamingContent("The Silence of the Lambs", "Hello, Clarice", MaturityRating.R, 8.6, 1991, GenreType.Horror);
                _repo.AddContentToDirectory(jaws);
                _repo.AddContentToDirectory(dieHard);
                _repo.AddContentToDirectory(silenceOfLambs);
        }
        
    }
}
