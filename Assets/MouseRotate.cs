using UnityEngine;using UnityEngine.InputSystem;

public class MouseRotate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector2 rotationImput;
    float rotationspeed=0.2f;
    void OnRotate(InputValue value)
    {
        rotationImput = value.Get<Vector2>();
    }
        
    

    // Update is called once per frame
    void Update()
    {
        var mouse = Mouse.current;
        if (mouse.rightButton.isPressed)
        {
            Debug.Log("dfiwg");
            transform.Rotate(Vector3.up, -rotationImput.x * rotationspeed, Space.World);
            transform.Rotate(Vector3.right, rotationImput.y* rotationspeed, Space.World);
        }
    }
}
