using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingObstacle : Obstacle
{
    protected private override void PlayerCollision()
    {
        base.PlayerCollision();
        Destroy(gameObject);
    }
}
