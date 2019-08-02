using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//doing another github test
public class Hacker : MonoBehaviour
{
    //game state
    int level;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;
    string password;

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
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }


    }//end OnUserInput()

    private void RunMainMenu(string input)
    {
        if (String.Compare(input, "1") == 0)
        {
            level = 1;  
            password = "poop";
            CheckPassword(input);
        }
        else if (String.Compare(input, "2") == 0)
        {
            level = 2;
            password = "blah";
            StartGame(level);
        }
        else if (String.Compare(input, "3") == 0)  //we can always go direct to menu
        {
            level = 3;
            password = "suck";
            StartGame(level);
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

    void StartGame(int lvl)
    {
        currentScreen = Screen.Password; 
        
        if(lvl == 1)
        {
            Terminal.WriteLine("we're in level 1");
        }
        else if (lvl == 2)
        {
            Terminal.WriteLine("we're in level 2");
        }
        else if (lvl == 3)
        {
            Terminal.WriteLine("we're in level 3");
        }
        
    }

    void CheckPassword(string input)
    {
        if(input == password)
        {
            Win();
        }
        else
        {
            Terminal.WriteLine("Wrong password");
            //RunMainMenu(level.ToString());

        }
    }

    void Win()
    {       
        Terminal.WriteLine("Congrats, you're correct!");        
    }
}
