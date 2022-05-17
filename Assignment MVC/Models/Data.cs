using System.Collections.Generic;
using System.Linq;

namespace Assignment_MVC.Models
{
    public class DataStore
    {
        public List<Project> Projects;
        public string adress = "Some street 1",zipcode="123 45 City";
        public int phoneNr = 12345743;
        

        public DataStore()
        {
            Projects = new List<Project>();
            Project p = new Project();
            p.link = "https://github.com/Jonas-swede/Calculator";
            p.title = "Calulator";
            p.text = "A small text based calculator";
            Projects.Add(p);

            p = new Project();
            p.link = "https://github.com/Jonas-swede/Assignment-4-Vending-Machine";
            p.title = "Vending Machine";
            p.text = "A vending machine that can hold products and take payment in set denomenations.";
            Projects.Add(p);

            p = new Project();
            p.link = "https://github.com/Jonas-swede/Hangman";
            p.title = "Hangman";
            p.text = "A hangman game in swedish and english";
            Projects.Add(p);

            p = new Project();
            p.link = "https://github.com/Jonas-swede/Assignment-1";
            p.title = "HTML page";
            p.text = "An assignment to construct a basic HTML page";
            Projects.Add(p);
        
            p = new Project();
            p.link = "https://github.com/Jonas-swede/JS-Assignment";
            p.title = "Sokoban";
            p.text = "A small Sokoban game written in javascript.";
            Projects.Add(p);


        }

       
        
    }

    
    public class Project
    {
        public string link, title, text;
    }
}
