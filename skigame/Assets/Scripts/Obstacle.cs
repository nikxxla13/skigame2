using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerCollision();
        }
    }

    protected private virtual void PlayerCollision()
    {
        PlayerEvents.callOnHitEvent();
        Debug.Log("Player hit" + name);
    }
}
