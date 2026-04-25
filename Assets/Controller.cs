using UnityEngine;
using UnityEngine.InputSystem;
public class Controller : MonoBehaviour
{
    public float speed = 10.0f;
    public float crawlX;
    public float crawlY;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb)
        {
            Debug.Log("We Slugging.");
        }
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        crawlX=movementVector.x;
        crawlY=movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(crawlX, 0.0f, crawlY);
        rb.AddForce(movement * speed);

        

    }

}

