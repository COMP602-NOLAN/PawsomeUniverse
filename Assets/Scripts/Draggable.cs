using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Rigidbody2D rb; // Reference to the Rigidbody component

    public float minY;
    public float maxY;

    void Start()
    {
        // Store the initial position and rotation when the game starts
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        // Get a reference to the Rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Set the Rigidbody's velocity to zero when dragging starts
        rb.velocity = Vector3.zero;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;

            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            // Set the new position while maintaining the X and Z values
            transform.position = new Vector3(newPosition.x, newPosition.y, 0f);
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        // Return the GameObject to its initial position and rotation
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        // Set the Rigidbody's velocity to zero when dragging ends
        rb.velocity = Vector3.zero;
    }
}
