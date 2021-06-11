using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{

    [SerializeField] GameObject Panel;
    public bool paused;
    // Update is called once per frame
    void Update() {
        if(Input.GetButtonDown("pausar")) {
            Pause();
        }
    }

    public void Pause() {
        if (paused) {
            Time.timeScale = 1;
            Panel.gameObject.SetActive(false);
            paused = false;
        } else if(!paused) {
            Time.timeScale = 0;
            Panel.gameObject.SetActive(true);
            paused = true;
        }
    }
}
