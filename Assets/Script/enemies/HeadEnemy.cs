using UnityEngine;

public class HeadEnemy : MonoBehaviour
{
    private normalZombie parentZombie;
    private Boss boss;
    private void Awake()
    {
        parentZombie = GetComponentInParent<normalZombie>();
        boss = GetComponentInParent<Boss>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(boss != null) { 
        if(collision.CompareTag("bullet"))
        {
                boss.PositionTakeDame(true,false);
        }
        if (collision.CompareTag("melle"))
        {
                boss.PositionTakeDame(true, true);
        }
        }
        if (parentZombie != null)
        {
            if (collision.CompareTag("bullet"))
            {
                parentZombie.PositionTakeDame(true, false);
            }
            if (collision.CompareTag("melle"))
            {
                parentZombie.PositionTakeDame(true, true);
            }
        }

        }
  
}
