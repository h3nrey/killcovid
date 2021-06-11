using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

    [SerializeField] GameObject projectille;
    [SerializeField] Transform projectillePoint;

    //timers
    [SerializeField] float shootTimer;

    //shooting flags
    bool shootting, readyToShoot, allowInvoke;

    //externals
    private PlayerBehaviour _playerBehaviour;
    private PauseController _pauseController;

    void Start() {
        readyToShoot = true;
        allowInvoke = true;
    }

    void Awake() {
        _playerBehaviour = FindObjectOfType<PlayerBehaviour>();
        _pauseController = FindObjectOfType<PauseController>();
    }

    void Update() {
        if(Input.GetButtonDown("Fire1")  && readyToShoot && !_pauseController.paused) {
            Shoot();
        }
    }

    void Shoot() {
        readyToShoot = false;
        Instantiate(projectille, projectillePoint.transform.position, Quaternion.identity);

        if(allowInvoke) {
            Invoke("ResetShoot", shootTimer);
            allowInvoke = false;
        }
    }

    void ResetShoot() {
        readyToShoot = true;
        allowInvoke = true;
    }
}
