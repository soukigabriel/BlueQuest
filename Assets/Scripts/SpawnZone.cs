using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    PlayerController thePlayer;
    Transform theMainCamera;
    Transform theVirtualCamera;
    public Vector2 facingDirection = Vector2.zero;

    public string m_SpawnPointName;

    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        if (!thePlayer.nextSpawnPoint.Equals(m_SpawnPointName))
        {
            return;
        }
        thePlayer.transform.position = this.transform.position;

        thePlayer.lastMovement = facingDirection;
    }

    [ContextMenu("SetPosition")]
    public void SetPosition()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        thePlayer.transform.position = this.transform.position;
    }
}
