using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public delegate void OnHit();
    public static event OnHit onHitEvent;

    public static void callOnHitEvent()
    {
        if (onHitEvent != null)
            onHitEvent();
    }
}
