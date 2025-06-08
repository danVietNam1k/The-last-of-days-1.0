using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] Transform _thisTransition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CONSTANT.Player))
            {
            collision.gameObject.transform.position = _thisTransition.position;
        }
    }
}
