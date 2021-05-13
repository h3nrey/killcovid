using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    [SerializeField] LayerMask Clickble;
    [SerializeField] Transform teste;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

        //rb.MovePosition(Vector3.MoveTowards(transform.position, teste.transform.position, speed));

        transform.position = Vector3.MoveTowards(transform.position, teste.transform.position, speed);
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit alvo;

            if (Physics.Raycast(ray, out alvo, 100, Clickble)) {
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(alvo.collider.transform.position.x,transform.position.y, transform.position.z), speed);

                //transform.position = Vector3.Lerp(transform.position, new Vector3(alvo.collider.transform.position.x, transform.position.y, transform.position.z), speed);

                teste.transform.position = new Vector3(alvo.collider.transform.position.x,transform.position.y,transform.position.z);
                //teste.transform.position = Vector3.Lerp(transform.position, new Vector3(alvo2.collider.transform.position.x, transform.position.y, transform.position.z), speed);
            }
        }
        /* float xInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = Vector2.right * xInput * speed; */
    }
}
