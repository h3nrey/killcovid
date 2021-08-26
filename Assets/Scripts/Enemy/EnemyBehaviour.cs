using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] int enemyLife;
    int currentLife;
    [SerializeField] Animator anim;
    [SerializeField] AudioSource AttackSound;
    [SerializeField] string enemyType;
    [SerializeField] ParticleSystem deathParticles;

    [Header("physics")]
    [SerializeField] Rigidbody enemyrb;
    [SerializeField] float enemyVelocity;
    [SerializeField] Vector3 EnemyDirection;

    [Header("Attack")]
    [SerializeField] int enemyDamage;
    [SerializeField] float rangeAttack = 3f;
    [SerializeField] LayerMask barrer;
    [SerializeField] Vector3 enemyDirectionAttack;
    [SerializeField] float AttackTime;
    [SerializeField] bool isRanged, readyToAttack, allowInvoke;

    //externals
    private barrerBehaviour _barrer;
    private CallScene _callScene;
    EnemySpawner _enemySpawn;
    private ScoreController _score;

    private void Awake() {
        _barrer = FindObjectOfType<barrerBehaviour>();
        _callScene = FindObjectOfType<CallScene>();
        _enemySpawn = FindObjectOfType<EnemySpawner>();
        _score = FindObjectOfType<ScoreController>();
    }

    void Start() {
        currentLife = enemyLife;
        allowInvoke = true;
        readyToAttack = true;
    }

    void Update() {
        if(isRanged == false){
            enemyrb.velocity = EnemyDirection * enemyVelocity * Time.deltaTime;
        } else if(isRanged == true) {
            enemyrb.velocity = Vector3.zero;
        }
    } 

    void FixedUpdate() {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, enemyDirectionAttack);

        if (Physics.Raycast(ray, out hit, rangeAttack, barrer) && readyToAttack) {
	        isRanged = true;
            EnemyAttackRanged(hit);
        } else if(!Physics.Raycast(ray, out hit, rangeAttack, barrer) && readyToAttack){ 
            isRanged = false;
        } 
    }

    void Takedemage(int damage) {
        currentLife -= damage;

        if (currentLife == 0) {
            deathParticles.Play();
            _enemySpawn.activeEnemies--;
            _score.virusKilled++;
            Destroy(this.gameObject);
        }
    }

    void EnemyAttackRanged(RaycastHit hit) {
        readyToAttack = false;
        anim.SetTrigger("Attack");
        hit.collider.gameObject.GetComponent<barrerBehaviour>().barrerTakeDamage(enemyDamage);
        //AttackSound.Play();

        if(allowInvoke) {
            Invoke("AllowInvoke", AttackTime);
            allowInvoke = false;
        }
    }

    void AllowInvoke() {
        allowInvoke = true;
        readyToAttack = true;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, enemyDirectionAttack * rangeAttack);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("end"))
        {
            _callScene.callScene("GameOver");
        }

        if (other.gameObject.tag == "projectille" && enemyType == "comum") {
            Takedemage(other.gameObject.GetComponent<ProjectilleBehaviour>().projectileDamage);
        }
        if(other.gameObject.tag == "breakProteinProjectille" && enemyType == "Big") {
            Takedemage(other.gameObject.GetComponent<ProjectilleBehaviour>().projectileDamage);
        }

    }
}
