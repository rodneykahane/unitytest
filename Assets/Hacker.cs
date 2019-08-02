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
        if (string.Compare(input, "menu") == 0)
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
    }//end OnUserInput()

    private void RunMainMenu(string input)
    {
        if (String.Compare(input, "1") == 0)
        {
            level = 1;
            StartGame();
        }
        else if (String.Compare(input, "2") == 0)
        {
            level = 2;
            StartGame();
        }
        else if (String.Compare(input, "3") == 0)  //we can always go direct to menu
        {
            level = 3;
            StartGame();
        }
        else if (String.Compare(input, "007") == 0)
        {
            Terminal.WriteLine("Please make a selection Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Press 1, 2, or 3");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("the difficulty level is: " + level);
        Terminal.WriteLine("Please enter your password: ");
    }
}
