using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.callRaceEnd();
        }
    }
}
