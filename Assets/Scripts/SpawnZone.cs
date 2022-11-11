using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [Tooltip("Reference to the player that will be spawned in this point")]
    PlayerController thePlayer;
    [Tooltip("Variable that will be used to define the direction the character will be looking for when spawned in this point")]
    public Vector2 facingDirection = Vector2.zero;
    [Tooltip("THe name of this spawn point")]
    public string m_SpawnPointName;

    private void Start()
    {
        //If in the start of the scene my m_SpawnPointName has the same value of nextSpawnPoint in the player reference found by his player controller component then set his position to this game object position and set his las movement, otherwise do nothing
        thePlayer = FindObjectOfType<PlayerController>();
        if (!thePlayer.nextSpawnPoint.Equals(m_SpawnPointName))
        {
            return;
        }
        thePlayer.transform.position = this.transform.position;

        thePlayer.lastMovement = facingDirection;
    }
}
