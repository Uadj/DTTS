using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private SpikeSpawner[] spikeSpawners;
    private UIController uIController;
    private int currentSpawn = 0;

    private void Awake()
    {
        uIController = GetComponent<UIController>();
    }
    private IEnumerator Start()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                uIController.GameStart();
                yield break;
            }
            yield return null;
        }
        
    }
    public void CollisionWithWall()
    {
        UpdateSpikes();
    }

    private void UpdateSpikes()
    {
        spikeSpawners[currentSpawn].ActivateAll();

        currentSpawn = (currentSpawn + 1) % spikeSpawners.Length;

        spikeSpawners[currentSpawn].DeactivateAll();
    }
    public void GameOver()
    {
        Debug.Log("GameOver");
    }
}
