using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{
    public string newSceneName = "New scene name here";
    public string destinationSpawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().nextSpawnPoint = destinationSpawnPoint;
            SceneManager.LoadScene(newSceneName);
        }
    }
}
