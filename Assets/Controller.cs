using UnityEngine;
using UnityEngine.InputSystem;
public class Controller : MonoBehaviour
{
InputAction sluggy;
private float crawlX;
private float crawlY;
private Rigidbody rb;
private void Start()
    {
        sluggy=InputSystem.actions.FindAction("Move");
    }
}

