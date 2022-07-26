using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private SpikeSpawner[] spikeSpawners;
    private int currentSpawn = 0;

    public void CollisionWithWall();

    public void GameOver()
    {

    }
}
