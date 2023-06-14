using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float lookUpLimit = 80f;

    private CharacterController controller;
    private float rotationX = 0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        // Lock cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Read input for movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement vector based on input and player's facing direction
        Vector3 moveDirection = (transform.forward * vertical) + (transform.right * horizontal);

        // Move the character controller
        controller.SimpleMove(moveDirection.normalized * speed);

        // Read input for rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the player horizontally
        transform.Rotate(0f, mouseX, 0f);

        // Rotate the player vertically (limit look up)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -lookUpLimit, lookUpLimit);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
