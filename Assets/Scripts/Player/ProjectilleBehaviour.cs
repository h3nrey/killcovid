using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilleBehaviour : MonoBehaviour {

    [Header("physics")]
    [SerializeField] Rigidbody Projectilerb;
    [SerializeField] float projectilleSpeed;
    [SerializeField] Vector3 projectilleDirection;
    [SerializeField] float LifeTime;

    [Header("Enemy")]
    [SerializeField] LayerMask enemyLayer;
    public int projectileDamage;


    private void Start() {
        InvokeRepeating("DestroyProjectille", LifeTime, 0);
    }
    private void FixedUpdate() {
        Projectilerb.AddForce(projectilleDirection * projectilleSpeed * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == enemyLayer || other.gameObject.tag == "enemy") {
            DestroyProjectille(); 
        }
    }

    void DestroyProjectille() {
        Destroy(this.gameObject);
    }
}
