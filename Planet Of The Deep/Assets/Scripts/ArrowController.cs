using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public Transform destination;
    public float distanceFromCamera = 1f;
    public float arrowSize = 1f;
    public Vector2 offset = new Vector2(0.5f, 0.5f); // The offset from the center of the screen

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Calculate the world position of the arrow based on the camera's forward direction and offset
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 arrowPosition = mainCamera.ViewportToWorldPoint(new Vector3(offset.x, offset.y, distanceFromCamera));

        // Position and scale the arrow based on the distance to the camera
        transform.position = arrowPosition;
        transform.localScale = Vector3.one * distanceFromCamera * arrowSize;

        // Rotate the arrow to point at the destination
        Vector3 direction = Vector3.Normalize(destination.position - arrowPosition);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}
