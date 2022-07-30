using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private SpikeSpawner[] spikeSpawners;
    private UIController uIController;
    private RandomColor randomColor;

    private int currentSpawn = 0;
    private int currentScore = 0;
    [SerializeField]
    private Player player;

    private void Awake()
    {
        randomColor = GetComponent<RandomColor>();
        uIController = GetComponent<UIController>();
    }
    private IEnumerator Start()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                player.GameStart();
                uIController.GameStart();
                yield break;
            }
            yield return null;
        }
        
    }
    public void CollisionWithWall()
    {
        UpdateSpikes();
        currentScore++;
        uIController.UpdateScore(currentScore);
        randomColor.OnChange();
    }

    private void UpdateSpikes()
    {
        spikeSpawners[currentSpawn].ActivateAll();

        currentSpawn = (currentSpawn + 1) % spikeSpawners.Length;

        spikeSpawners[currentSpawn].DeactivateAll();
    }
    public void GameOver()
    {
        StartCoroutine(nameof(GameOverProcess));
    }
    private IEnumerator GameOverProcess()
    {
        if(currentScore > PlayerPrefs.GetInt("HIGHSCORE"))
        {
            PlayerPrefs.SetInt("HIGHSCORE", currentScore);
        }
        uIController.GameOver();
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
            yield return null;
        }
    }
}
