using UnityEngine;


public class Collider : MonoBehaviour
{
    public float sensititvity = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnMouseDrag()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensititvity;
        float mouseY = Input.GetAxis("Mouse Y") * sensititvity;

        transform.Rotate(Vector3.up, -mouseX, Space.World);
        transform.Rotate(Vector3.right, mouseY, Space.World);
    }
}
