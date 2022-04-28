using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LamdaExamples : MonoBehaviour
{
    private string playerName;

    // Lambda can be used for properties. This is a get only property
    public string PlayerNameLambdaGetter => playerName;

    // Shorthand of writing a full getter/setter
    public string PlayerNameNormalGetter
    {
        get
        {
            return playerName;
        }
    }

    // Can also be used for both Getter and Setter
    // Note there are no braces
    public string PlayerNameGetterSetterLambda
    {
        get => playerName;
        set => playerName = value;
    }



    // Another form or Lambda Expression is a shortend function
    // Note we don't have braces or "return" if it's in one line.
    public int Add(int a, int b) => a + b;




    public class Player
    {
        public string name;
        public int ID;

        // other player data
    }

    // Another form of methods using Lambda/ Fat Arrow operator are anonymous methods
    // Anonymous methods don't have a name and are meant to be only called once and thrown away
    List<Player> players = new List<Player>();


    public Player GetPlayerByNameNormalFunction(string playerName)
    {
        Player foundPlayer = null;

        // The normal way is either using a for loop or a foreach loop
        foreach (Player player in players)
        {
            if (player.name == playerName)
            {
                foundPlayer = player;
                break;
            }
        }

        return foundPlayer;
    }
    
    public Player GetPlayerByNameAnonymousFunction(string playerName)
    {
        // We can use an Anonymous Method for in-line use and to throw away after we're done,
        // as it won't be used anywhere else except in this case

        Player foundPlayer = players.Find(player => player.name == playerName);
        
        return foundPlayer;
    }



    // We also use anonymous methods as "callback" functions
    // Meaning that we provide a function that does things. However, this function is not called right away
    // Instead, it's called only when something happens during play, where we can't manually call it because we don't know when it's needed
    // Buttons are a perfect example
    
    Button myButton;

    void SetupButtonWhenClicked()
    {
        // We want some functionality to only happen once button is clicked
        // We give it an anonymous functin as a delegate to be called at that time

        // Note that we can use braces and semi-colons like normal code, if we need a function that takes more than one line
        myButton.onClick.AddListener(() =>
        {
            GetPlayerByNameAnonymousFunction("Doggo");
            Add(2, 4);
        });
    }
}

