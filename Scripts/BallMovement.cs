using Photon.Pun;
using UnityEngine;

public class BallMovement : MonoBehaviourPun
{
    Vector3 velocity = Vector3.zero;
    Rigidbody rb;
    [SerializeField]
    float moveSpeed = 0f, jumpForce = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Boundaries();
    }

    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if (touch.position.x < Screen.width / 2)
                {
                    velocity.x += -moveSpeed * Time.deltaTime;
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    velocity.x += moveSpeed * Time.deltaTime;
                }
            }
            transform.position += velocity;
        }
    }

    private void OnMouseDown()
    {
        if (photonView.IsMine)
            rb.AddForce(Vector3.up * jumpForce);
    }

    void Boundaries()
    {
        if (transform.position.x <= -8f)
            transform.position = new Vector3(-8f, transform.position.y, 5f);
        if (transform.position.x >= 8f)
            transform.position = new Vector3(8f, transform.position.y, 5f);
    }
}