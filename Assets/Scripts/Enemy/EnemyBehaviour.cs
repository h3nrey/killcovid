using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] int enemyLife;
    int currentLife;
    

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
    [SerializeField] bool isRanged;

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
    }

    // Update is called once per frame
    void Update() {
        enemyrb.velocity = EnemyDirection * enemyVelocity * Time.deltaTime;
    }

    void FixedUpdate() {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, enemyDirectionAttack);
        if (Physics.Raycast(ray, out hit, rangeAttack, barrer)) {
            StartCoroutine(EnemyAttack(hit));
        }
    }


    void Takedemage(int damage) {
        currentLife -= damage;

        if(currentLife == 0) {
            _enemySpawn.activeEnemies --;
            _score.virusKilled ++;
            Destroy(this.gameObject);
        }
    }

    IEnumerator EnemyAttack(RaycastHit hit) {
        //toca animação de ataque
        yield return  new WaitForSeconds(AttackTime);
        Debug.Log("atingiu");
        hit.collider.gameObject.GetComponent<barrerBehaviour>().barrerTakeDamage(enemyDamage);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, enemyDirectionAttack * rangeAttack);
    }
    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("end")) {
            _callScene.callScene("GameOver");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("end")) {
            _callScene.callScene("GameOver");
        }

        if(other.gameObject.tag == "projectille") {
            Takedemage(other.gameObject.GetComponent<ProjectilleBehaviour>().projectileDamage);
        }
    }
}
