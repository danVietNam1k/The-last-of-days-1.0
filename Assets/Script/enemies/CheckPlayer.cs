using Unity.VisualScripting;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    private normalZombie parentZombie;

    private void Awake()
    {
        parentZombie = GetComponentInParent<normalZombie>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            parentZombie?.OnPlayerDetected(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            parentZombie?.OnPlayerDetected(false);
        }
    }
}
