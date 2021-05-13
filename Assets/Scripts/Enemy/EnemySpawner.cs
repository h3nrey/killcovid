using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] Transform[] spawnerPoints;
    [SerializeField] GameObject[] enemyPrefabs;

    [SerializeField] int enemiesPerWave, enemiesPerWaveMultiply;
    public int activeEnemies;
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

            Instantiate(enemyPrefabs[enemyIndexArray], spawnerPoints[enemyPointIndexArray].transform.position, Quaternion.identity);
            activeEnemies++;
        }

        switch(_score.virusKilled) {
            case 5:
                enemiesPerWave += enemiesPerWaveMultiply;
                break;

            case 1:
                FindObjectOfType<CallScene>().callScene("WonScreen");
                break;
        }
    }
}
