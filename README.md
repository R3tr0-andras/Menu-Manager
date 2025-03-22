# Menu Manager Documentation
## 1. Introduction
Menu-Manager est une bibliothèque en C# permettant de créer des menus interactifs en console avec gestion des couleurs et des erreurs.
## 2. Fonctionnalités
- Création dynamique de menus interactifs
- Gestion des couleurs pour le titre, les options et les erreurs
- Vérification des entrées utilisateur et gestion des erreurs
- Possibilité d'imbriquer plusieurs menus
## 3. Installation
Ajoutez le dossier AndrasLib contenant MenuManager.cs à votre projet C#.
## 4. Utilisation
### 4.1. Exemple de code
```cs
using System;
using UtilityLibrary;

class Program
{
    static void Main()
    {
        MenuManager mainMenu = new MenuManager("Menu Principal");
        mainMenu.SetColors(ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Red);
        
        mainMenu.AddOption("1", "Dire Bonjour", () => Console.WriteLine("Bonjour !"));
        mainMenu.AddOption("2", "Afficher l'heure", () => Console.WriteLine($"Heure actuelle : {DateTime.Now}"));
        mainMenu.AddOption("3", "Aller au sous-menu", ShowSubMenu);
        
        mainMenu.ShowMenu();
    }
    
    static void ShowSubMenu()
    {
        MenuManager subMenu = new MenuManager("Sous-Menu");
        subMenu.AddOption("1", "Retour au menu principal", () => Console.WriteLine("Retour au menu principal..."));
        subMenu.ShowMenu();
    }
}
```
### 4.2. Personnalisation
Vous pouvez modifier les couleurs avec la méthode SetColors :
```cs
menu.SetColors(ConsoleColor.Yellow, ConsoleColor.White, ConsoleColor.Red);
```
## 5. API Reference
### 5.1. Classe MenuManager
Constructeur
```cs
public MenuManager(string title)
```
'title' : Nom du menu affiché en console.

Méthodes
```cs
public void SetColors(ConsoleColor titleColor, ConsoleColor optionColor, ConsoleColor errorColor)
```
Définit les couleurs du menu.
```cs
public void AddOption(string key, string description, Action action)
```
Ajoute une option au menu.
```cs
public void ShowMenu()
```
Affiche le menu et gère les choix utilisateur.

## 6. Contribution
Les contributions sont les bienvenues ! Vous pouvez soumettre des pull requests ou signaler des problèmes.

## 7. Licence
Ce projet est sous licence MIT.
