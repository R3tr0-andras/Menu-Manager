using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrairieMenu
{
    // Classe qui gère l'affichage et la gestion d'un menu interactif
    public class MenuManager
    {
        // Dictionnaire contenant les options du menu (clé, description et action associée)
        private Dictionary<string, (string Description, Action Action)> options;
        private string title; // Titre du menu
        private ConsoleColor titleColor = ConsoleColor.Cyan; // Couleur du titre
        private ConsoleColor optionColor = ConsoleColor.Yellow; // Couleur des options
        private ConsoleColor errorColor = ConsoleColor.Red; // Couleur des messages d'erreur

        // Constructeur qui initialise le menu avec un titre
        public MenuManager(string title)
        {
            this.title = title;
            options = new Dictionary<string, (string, Action)>();
        }

        // Méthode pour définir les couleurs du menu
        public void SetColors(ConsoleColor titleColor, ConsoleColor optionColor, ConsoleColor errorColor)
        {
            this.titleColor = titleColor;
            this.optionColor = optionColor;
            this.errorColor = errorColor;
        }

        // Méthode pour ajouter une option au menu
        public void AddOption(string key, string description, Action action)
        {
            if (!options.ContainsKey(key))
            {
                options.Add(key, (description, action));
            }
            else
            {
                Console.ForegroundColor = errorColor;
                Console.WriteLine($"Option {key} already exists!");
                Console.ResetColor();
            }
        }

        // Méthode pour afficher le menu et gérer les choix de l'utilisateur
        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear(); // Nettoie l'écran avant d'afficher le menu

                Console.ForegroundColor = titleColor;
                Console.WriteLine("====================");
                Console.WriteLine(title); // Affiche le titre du menu
                Console.WriteLine("====================");
                Console.ResetColor();

                // Affiche chaque option du menu avec sa clé et sa description
                foreach (var option in options)
                {
                    Console.ForegroundColor = optionColor;
                    Console.WriteLine($"{option.Key}: {option.Value.Description}");
                    Console.ResetColor();
                }
                Console.WriteLine("Q: Quit"); // Option pour quitter le menu
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine()?.Trim(); // Lecture et nettoyage de l'entrée utilisateur
                if (string.IsNullOrEmpty(choice))
                {
                    Console.ForegroundColor = errorColor;
                    Console.WriteLine("Input cannot be empty. Press Enter to try again...");
                    Console.ResetColor();
                    Console.ReadLine();
                    continue;
                }

                if (choice.ToUpper() == "Q") break; // Quitte la boucle si l'utilisateur choisit 'Q'

                if (options.ContainsKey(choice)) // Vérifie si l'option existe
                {
                    try
                    {
                        options[choice].Action.Invoke(); // Exécute l'action associée
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = errorColor;
                        Console.WriteLine($"An error occurred: {ex.Message}"); // Gère les erreurs éventuelles
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = errorColor;
                    Console.WriteLine("Invalid choice, press Enter to continue..."); // Message d'erreur si option invalide
                    Console.ResetColor();
                }
                Console.ReadLine(); // Pause avant de réafficher le menu
            }
        }
    }
}
