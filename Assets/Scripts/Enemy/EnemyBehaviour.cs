using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] int enemyLife;
    int currentLife;
    

    //physics
    [SerializeField] Rigidbody enemyrb;
    [SerializeField] float enemyVelocity;
    [SerializeField] Vector3 EnemyDirection;

    //Attack
    [SerializeField] int enemyDamage;
    [SerializeField] float rangeAttack = 3f;
    [SerializeField] LayerMask barrer;
    [SerializeField] Vector3 enemyDirectionAttack;

    //externals
    private barrerBehaviour _barrer;
    private CallScene _callScene;

    private void Awake() {
        _barrer = FindObjectOfType<barrerBehaviour>();
        _callScene = FindObjectOfType<CallScene>();
    }

    void Start() {
        currentLife = enemyLife;
    }

    // Update is called once per frame
    void Update() {
        enemyrb.velocity = EnemyDirection * enemyVelocity * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("end")) {
            _callScene.callScene("GameOver");
        }

        if(collision.gameObject.CompareTag("barrer")) {
            collision.gameObject.GetComponent<barrerBehaviour>().barrerTakeDamage(enemyDamage);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("end"))
        {
            _callScene.callScene("GameOver");
        }
    }
    void Takedemage(int damage) {
        currentLife -= damage;

        if(currentLife == 0) {
            Destroy(this.gameObject);
        }
    }

    /*void EnemyAttack() {
        if (Physics.Raycast(transform.position, enemyDirectionAttack,rangeAttack, barrer)) {
            //play attack animation
            
        }
    }*/
}
