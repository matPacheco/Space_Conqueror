using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
    public int hazardWaves;
    public float spawnWait;
	public float startWait;
    public float waveWait;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverObject;

    private bool gameOver;
    private bool restart;
    private int score;

    public GameObject boss;

    public GameObject restartButton;

    void Start ()
	{
        gameOver = false;
        restart = false;
        score = 0;
        UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.R))
            {
                Restart();
            }
        }
    }

    IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
        for (int i = 0; i < hazardWaves; i++)
        {
            for (int j = 0; j < hazardCount; j++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartButton.SetActive(true);
                restart = true;
                break;
            }

        }
        if (restart != true)
        {
            Vector3 spawnPositionBoss = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0, 11);
            Quaternion spawnRotationBoss = Quaternion.Euler(0, 180, 0);
            Instantiate(boss, spawnPositionBoss, spawnRotationBoss);
        }

    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore ()
    {
        scoreText.text = "Pontuação: " + score;
    }

    public void GameOver ()
    {
        gameOverObject.SetActive(true);
        gameOver = true;
        restartButton.SetActive(true);
        restart = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
}
