using UnityEngine;
using UnityEngine.InputSystem;

public class gun : MonoBehaviour
{
    public Camera playerCamera;
    public float range = 100f;
    public int damage = 25;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("LEFT CLICK DETECTED");
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("GUN FIRED");

        RaycastHit hit;

        if (Physics.Raycast(
            playerCamera.transform.position,
            playerCamera.transform.forward,
            out hit,
            range))
        {
            Debug.Log("SHOT HIT: " + hit.transform.name);

            // Look on the object AND its parents for EnemyHealth
            EnemyHealth enemy =
                hit.transform.GetComponentInParent<EnemyHealth>();

            if (enemy != null)
            {
                Debug.Log("ENEMY HIT! Dealing " + damage + " damage.");
                enemy.TakeDamage(damage);
            }
            else
            {
                Debug.Log("Object was hit, but it does not have EnemyHealth.");
            }
        }
        else
        {
            Debug.Log("SHOT MISSED");
        }
    }
}