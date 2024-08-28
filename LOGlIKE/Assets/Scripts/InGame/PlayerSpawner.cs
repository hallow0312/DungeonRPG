using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject playerSpawner;

    private void Start()
    {
        GameObject playerobject = GameObject.FindWithTag("Player");
        if(playerobject!=null)
        {
            playerobject.transform.position = playerSpawner.transform.position;
        }
    }
}
