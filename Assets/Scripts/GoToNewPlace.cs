using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{
    [Header("Variables to travel through scenes")]
    [Tooltip("The name of the scene this change zone is linked to")]
    public string newSceneName = "New scene name here";
    [Tooltip("The name of the spawn point the player is expected to spawn when interact with this change zone")]
    public string destinationSpawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When the player enter on the trigger of this change zone his nextSpawnPoint value is set to this destinationSpawnPoint value and then the new scene is loaded
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().nextSpawnPoint = destinationSpawnPoint;
            SceneManager.LoadScene(newSceneName);
        }
    }
}
