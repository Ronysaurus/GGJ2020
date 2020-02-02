using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawner;
    private float waveTime;

    private int numEnemy;

    private int spawnIndex;

    private void Start()
    {
        waveTime = 20;
        StartCoroutine(WaveManager());
    }

    private IEnumerator WaveManager()
    {
        yield return new WaitForSeconds(waveTime);
        StartCoroutine(Spawn());
        spawnIndex++;
        spawnIndex %= spawner.Length;
        StartCoroutine(WaveManager());
    }

    private IEnumerator Spawn()
    {
        for (int i =0; i < 5; i++)
        {
            yield return new WaitForSeconds(3);
            SpawnEnemies();
        }
        /*
        if (numEnemy < 5)
        {
            Debug.Log("Hello There");
            numEnemy++;
            StartCoroutine(Spawn());
        }
        else
        {
            numEnemy = 0;
        }
        */
    }

    private void SpawnEnemies()
    {
        Enemigo myEnemy = Instantiate(enemy, spawner[spawnIndex]).GetComponent<Enemigo>();
        myEnemy.spawnIndex = spawnIndex;
    }
}