using UnityEngine;

public class TransitionMainMap : MonoBehaviour
{
    [SerializeField] Transform _thisTransition;
    [SerializeField] GameObject _player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CONSTANT.Player))
            {
            collision.gameObject.transform.position = _thisTransition.position;
        }
    }
}
