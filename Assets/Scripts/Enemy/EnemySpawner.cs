using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] Transform[] spawnerPoints;
    [SerializeField] GameObject[] enemyPrefabs;

    [SerializeField] int enemiesPerWave, enemiesPerWaveMultiply, enemyInstantiate;
    public int activeEnemies, enemiesToWin;
    [SerializeField] float timeBetweenSpawn, timeToStart;
    int enemyPointIndexArray, enemyIndexArray;

    //externals
    private ScoreController _score;
    void Start() {
        InvokeRepeating("EnemySpawn", timeToStart, timeBetweenSpawn);
    }

    private void Awake() {
        _score = FindObjectOfType<ScoreController>();
    }

    void Update() {
    }

    void EnemySpawn() {
        if (activeEnemies <= enemiesPerWave) {
            enemyPointIndexArray = Random.Range(0, spawnerPoints.Length);
            enemyIndexArray = Random.Range(0, enemyPrefabs.Length);

            if (enemyInstantiate < enemiesToWin) { 
                Instantiate(enemyPrefabs[enemyIndexArray], spawnerPoints[enemyPointIndexArray].transform.position, Quaternion.identity);
                activeEnemies++;
                enemyInstantiate++;
            }
        }

        switch(_score.virusKilled) {
            case 5:
                enemiesPerWave += enemiesPerWaveMultiply;
                break;

            case 10:
                enemiesPerWave += enemiesPerWaveMultiply;
                break;

            case 15:
                enemiesPerWave += enemiesPerWaveMultiply;
                break;
            case 20:
                FindObjectOfType<CallScene>().callScene("WonScreen");
                break;
        }
    }
}
