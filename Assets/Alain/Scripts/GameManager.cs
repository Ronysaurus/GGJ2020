using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float timeSpeed = 1.0f;

    public GameObject enemy;
    public Transform[] spawner;
    private float waveTime;

    private int spawnIndex;

    public int hp;

    private void Update()
    {
        foreach (var enemy in FindObjectsOfType<Scr_EnemyStats>())
            enemy.SetSpeed(0.025f * timeSpeed);
    }

    private void Start()
    {
        waveTime = 20;
        StartCoroutine(startGame());
    }

    private IEnumerator startGame()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(WaveManager());
    }

    public void damage()
    {
        hp -= 1;
        if (hp <= 0)
            GameOver();
    }

    public void GameOver()
    {
        SoundManagerScript.PlaySound("boom");
        FindObjectOfType<Scr_PlayerControl>().GetHit(9999);
        StartCoroutine(TimeStop());
        hp = 0;
        FindObjectOfType<Scr_PlayerStats>().SetHp(0);
        foreach(var enemy in FindObjectsOfType<Enemigo>())
        {
            Destroy(enemy.gameObject);
        }
    }

    private IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(5);
        Time.timeScale = 0;
        SceneManager.LoadScene(3);
    }

    private IEnumerator WaveManager()
    {
        StartCoroutine(Spawn());
        spawnIndex++;
        spawnIndex %= spawner.Length;
        yield return new WaitForSeconds(waveTime);
        StartCoroutine(WaveManager());
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(3);
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        Enemigo myEnemy = Instantiate(enemy, spawner[spawnIndex]).GetComponent<Enemigo>();
        myEnemy.spawnIndex = spawnIndex;
    }
}