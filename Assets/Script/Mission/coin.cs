using UnityEngine;

public class coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CONSTANT.Player))
        {
            AudioManager.Instance.PlayAuCoin(); 
            Destroy(this.gameObject);

        }
    }

}
