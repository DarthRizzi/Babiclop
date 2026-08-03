using UnityEngine;

public class FPSController : MonoBehaviour
{
    [Header("Referências")]
    public Transform cameraTransform;
 
    [Header("Movimentação")]
    public float moveSpeed = 5f;
    public float sprintMultiplier = 1.6f;
 
    [Header("Câmera")]
    public float mouseSensitivity = 200f;
    public float minPitch = -80f; 
    public float maxPitch = 80f;  
    private float pitch = 0f;
 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
 
    void Update()
    {
        HandleMouseLook();
        HandleMovement();
 
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
 
        if (Input.GetMouseButtonDown(0) && Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
 
    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
 
        transform.Rotate(Vector3.up * mouseX);
 
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
 
        if (cameraTransform != null)
        {
            cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        }
    }
 
    void HandleMovement()
    {
        float h = Input.GetAxisRaw("Horizontal"); 
        float v = Input.GetAxisRaw("Vertical");
 
        float speed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
            speed *= sprintMultiplier;
 
        Vector3 move = (transform.forward * v + transform.right * h).normalized;
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
}
 