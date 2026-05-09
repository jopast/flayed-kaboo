
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraOrbit : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Orbit Settings")]
    public float orbitSpeed = 3f;
    public float verticalClampMin = -30f;
    public float verticalClampMax = 80f;

    [Header("Camera Position")]
    public float distance = 8f;
    public float heightOffset = 2f;

    [Header("Collision")]
    public float collisionRadius = 0.3f;       // size of the sweep sphere
    public float collisionPadding = 0.2f;      // keep camera this far from surface
    public LayerMask collisionLayers;          // set to "Default" or your map layer

    private float _yaw = 0f;
    private float _pitch = 20f;

    private void Start()
    {
        Vector3 dir = transform.position - target.position;
        _yaw = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
    }

    private void LateUpdate()
    {
        if (Mouse.current.rightButton.isPressed)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            _yaw += mouseDelta.x * orbitSpeed;
            _pitch -= mouseDelta.y * orbitSpeed;
            _pitch = Mathf.Clamp(_pitch, verticalClampMin, verticalClampMax);
        }

        Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0f);
        Vector3 offset = new Vector3(0f, heightOffset, -distance);

        // Where the camera WANTS to be
        Vector3 desiredPosition = target.position + rotation * offset;

        // Resolve collision between pivot and desired position
        Vector3 resolvedPosition = ResolveCollision(target.position, desiredPosition);

        transform.position = resolvedPosition;
        transform.LookAt(target.position + Vector3.up * heightOffset * 0.5f);
    }

    private Vector3 ResolveCollision(Vector3 from, Vector3 desired)
    {
        Vector3 direction = desired - from;
        float desiredDistance = direction.magnitude;

        // SphereCast from pivot toward desired camera position
        if (Physics.SphereCast(
                from,
                collisionRadius,
                direction.normalized,
                out RaycastHit hit,
                desiredDistance,
                collisionLayers))
        {
            // Pull camera in to just in front of the hit surface
            float safeDistance = Mathf.Max(hit.distance - collisionPadding, 0f);
            return from + direction.normalized * safeDistance;
        }

        return desired;
    }
}