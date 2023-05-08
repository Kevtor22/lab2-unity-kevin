using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 10;
    public float jumpHeight = 10;

    public int jumpsUsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= 5;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, rb.velocity.z);

        if (Input.GetKeyDown(KeyCode.Space) && jumpsUsed < 2)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
            jumpsUsed++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsUsed = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsUsed = 1;
        }
    }
}
