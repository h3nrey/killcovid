using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    [SerializeField] LayerMask Clickble;
    [SerializeField] Transform local;
    public bool moving;

    //externals
    private PauseController _pauseController;
    void Awake() {
        _pauseController = FindObjectOfType<PauseController>();
    }

    
    void Update() {
        rb.MovePosition(Vector3.MoveTowards(transform.position, local.transform.position, speed));

        if (rb.IsSleeping()) {
            moving = true;
        }
        else {
            moving = false;
        }

        if (Input.GetMouseButtonDown(1)  && !_pauseController.paused) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit alvo;

            if (Physics.Raycast(ray, out alvo, 100, Clickble)) {
                local.transform.position = new Vector3(alvo.collider.transform.position.x, alvo.collider.transform.position.y,transform.position.z);
            }
        }
    }
}
