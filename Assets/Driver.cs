using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1000f;
    [SerializeField] float moveSpeed = 30f;
    [SerializeField] float slowSpeed = 20f;
    [SerializeField] float boostSpeed = 40f;
    [SerializeField] float time=0.2f;
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal")*steerSpeed * Time.deltaTime;
        float carSpeed = Input.GetAxis("Vertical")* moveSpeed* Time.deltaTime;
        transform.Rotate(0,0 , -steerAmount);
        transform.Translate(0, carSpeed, 0 );
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Boost"){
            Debug.Log("boost");
            moveSpeed = boostSpeed;
            Destroy(other.gameObject, time);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag != "Boost") {
            moveSpeed = slowSpeed;
        }
    }
}
