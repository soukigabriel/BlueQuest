using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enum of each posible state that the game could be on
public enum GameState { mainMenu, inGame, shoping, inInventory, inPause };

public class GameManager : MonoBehaviour
{
    [Tooltip("The current state of the game. Is used to define what things can be or can't be done during each state")]
    public GameState currentGameState;
    public static GameManager sharedInstance;

    private void Awake()
    {
        if(sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
