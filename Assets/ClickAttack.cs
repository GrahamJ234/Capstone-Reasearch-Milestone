using UnityEngine;
using UnityEngine.InputSystem;

public class ClickAttack : MonoBehaviour
{
    public int damage = 25;
    public float range = 100f;

    void Update()
    {
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("CLICK REGISTERED");

            Attack();
        }
    }

    void Attack()
    {
        Camera cam = Camera.main;

        if (cam == null)
        {
            Debug.LogError("NO MAIN CAMERA FOUND");
            return;
        }

        Ray ray = cam.ViewportPointToRay(
            new Vector3(0.5f, 0.5f, 0f)
        );

        RaycastHit hit;

        int playerLayer = LayerMask.GetMask("Player");
        int layerMask = ~playerLayer;

        if (Physics.Raycast(ray, out hit, range, layerMask))
        {
            Debug.Log("HIT: " + hit.transform.name);

            EnemyHealth enemy =
                hit.transform.GetComponentInParent<EnemyHealth>();

            if (enemy != null)
            {
                Debug.Log("ENEMY FOUND");

                enemy.TakeDamage(damage);
            }
            else
            {
                Debug.Log("Hit something, but it wasn't the enemy.");
            }
        }
        else
        {
            Debug.Log("CLICK MISSED");
        }
    }
}