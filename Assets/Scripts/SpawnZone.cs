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
        theMainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        theVirtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera").transform;

        if (!thePlayer.nextSpawnPoint.Equals(m_SpawnPointName))
        {
            return;
        }
        thePlayer.transform.position = this.transform.position;
        //theMainCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theMainCamera.transform.position.z);
        theVirtualCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theVirtualCamera.transform.position.z);

        thePlayer.lastMovement = facingDirection;
    }
}
