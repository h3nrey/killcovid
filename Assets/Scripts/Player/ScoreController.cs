using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public int virusKilled = 0;
    [SerializeField] TMP_Text scoreText;


    //externals
    private EnemySpawner _spawner;
    void Awake() {
        _spawner = FindObjectOfType<EnemySpawner>();

        scoreText.text = $"{virusKilled} / {_spawner.enemiesToWin}";
    }

    // Update is called once per frame
    void Update(){
        scoreText.text = $"{virusKilled} / {_spawner.enemiesToWin}";
    }
}
