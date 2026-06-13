using UnityEngine;
using UnityEngine.InputSystem;
public class Controller : MonoBehaviour
{
    public float speed = 10.0f;
    public float crawlX;
    public float crawlY;
    public Camera Cam;
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
        
        Vector3 rtransform = Cam.transform.right;
        Vector3 rtransforward=Cam.transform.forward;
        rtransform.y=0;
        rtransforward.y = 0;
        rtransform.Normalize();
        rtransforward.Normalize();
        Vector3 movement =(rtransforward*crawlY+rtransform*crawlX);
        rb.AddForce(movement * speed, ForceMode.Force);

    }

}

