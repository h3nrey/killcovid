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

    void Start() {
        readyToShoot = true;
        allowInvoke = true;
    }

    void Update() {
        if(Input.GetButtonDown("Fire1")  && readyToShoot) {
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
