using UnityEngine;

public abstract class BehaviorEnemies : MonoBehaviour
{
    float _Hp;

    
    public static Vector3 RamdomTargetMove(Vector3 rangeOfMove)
    {
        Vector3 move = new Vector3();
        move.x = Random.Range(rangeOfMove.x - 5f, rangeOfMove.x + 5f);
        move.y = Random.Range(rangeOfMove.y - 5f, rangeOfMove.y + 5f);
        return move;
    }
    protected virtual void AtkDamge(int Damge,Collider2D colision)
    {
        if (colision.CompareTag("Player"))
        {
            NewMonoBehaviourScript atk = GetComponent<NewMonoBehaviourScript>();
            if(atk != null) 
                atk.TakeDame(Damge);
        }

    }

    
}
