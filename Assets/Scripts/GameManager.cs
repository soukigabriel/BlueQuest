using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { mainMenu, inGame, shoping, inInventory, inPause };

public class GameManager : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
