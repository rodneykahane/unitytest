using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //game state
    int level;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;
    string password;
    int tries = 0;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }
   
    //void ShowMainMenu(string poop)
    void ShowMainMenu() 
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();       
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
    }    

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }//end OnUserInput()

    private void RunMainMenu(string input)
    {
        string[] passwords = { "poop", "suckit", "bollocks" };
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber)
        {            
            level = int.Parse(input);
            password = passwords[level - 1];
            StartGame(level);
        }   
        else if (String.Compare(input, "007") == 0)  //easter egg :O
        {
            Terminal.WriteLine("Please make a selection Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Press 1, 2, or 3");
        }
        
    }   

    void StartGame(int lvl)
    {
        currentScreen = Screen.Password;
        

        switch (lvl)
        {
            case 1:
                Terminal.ClearScreen();
                string[] easyHash = { "POPO", "OOPP", "OPPO" };
                int index = UnityEngine.Random.Range(0, easyHash.Length);  //using random here for practice, the max value in Unity.Random.Range is actually max-1, ie (0,10) works out to (0,9)
                Terminal.WriteLine("The hash is: " + easyHash[index]);
                break;

            case 2:
                Terminal.ClearScreen();
                string[] medHash = { "SKTIUC", "TUCIKS", "SKICUT" };
                Terminal.WriteLine("The hash is: " + medHash[tries]);
                break;

            case 3:
                Terminal.ClearScreen();
                string[] hardHash = { "LOBLSKOC", "LSKOCLOB", "KOCLOBLSK" };
                Terminal.WriteLine("The hash is: " + hardHash[tries]);
                break;
            default:
                Debug.LogError("Invalid level number!");
                break;
        }
    }
    

    void CheckPassword(string input)
    {
        if(input == password && tries <= 3)
        {
            Win();
        }
        else if (tries == 2)
        {
            Fail();
        }
        else
        {
            Terminal.WriteLine("Wrong password");
            tries++;
            StartGame(level);
        }
    }

    void Win()
    {       
        Terminal.WriteLine("Congrats, you're correct!");        
        Terminal.WriteLine("Type 'menu' and try a harder level!");
        tries = 0;
    }

    void Fail()
    {
        Terminal.WriteLine("You did not get it right");
        Terminal.WriteLine("Type 'menu' to go back to the main menu");
        tries = 0;
    }
}//end class