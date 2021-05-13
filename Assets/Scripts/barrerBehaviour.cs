using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrerBehaviour : MonoBehaviour {
    [SerializeField] int Life;
    int currentLife;

    private void Awake() {
        currentLife = Life;
    }

    private void Update() {
        
    }
    public void barrerTakeDamage(int enemydamage) {
        currentLife -= enemydamage;

        if(currentLife <= 0) {
            Destroy(this.gameObject);
        }
    }
}

