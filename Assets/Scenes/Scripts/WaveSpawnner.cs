using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSpawnner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public float timeBetweenWaves = 10f;
    public Transform spawnPoint;
    public Text waveCountdownText;
    private float countdown = 20f; 
    private int waveIndex = 0 ;
    public GameManager gameManager;
    void Update ()
    {
        if(EnemiesAlive>0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {

            gameManager.WinLevel();
            this.enabled = false;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}",countdown);
    }
    IEnumerator SpawnWave ()
    {
        
        PlayerStats.rounds++;
            Wave wave = waves[waveIndex];

        for (int i = 0; i <wave.count ; i++)
        {
            SpawnEnemy(wave.enemy);

            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
      

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
