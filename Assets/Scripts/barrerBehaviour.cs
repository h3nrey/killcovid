using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrerBehaviour : MonoBehaviour {
    [SerializeField] int Life = 100;
    //[SerializeField] Animator anim;
    int currentLife;

    private void Awake() {
        currentLife = Life;
    }

    private void Update() {
        
    }
    public void barrerTakeDamage(int enemydamage) {
        //anim.SetTrigger("Attacked");
        currentLife -= enemydamage;

        if(currentLife <= 0) {
            Destroy(this.gameObject);
        }
    }
}

