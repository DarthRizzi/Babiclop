using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera playerCamera;

    [Header("Raycast")]
    [SerializeField] private float interactionDistance = 5f;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            FireRaycast();
        }
    }

    private void FireRaycast()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            if (hit.collider.CompareTag("Utensil"))
            {
                UtensilManager utensil = hit.collider.GetComponent<UtensilManager>();

                if (utensil != null)
                {
                    utensil.UseUtensil();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (playerCamera == null)
            return;

        Gizmos.color = Color.green;

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        Gizmos.DrawRay(ray.origin, ray.direction * interactionDistance);
    }
}