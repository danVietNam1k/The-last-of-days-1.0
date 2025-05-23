using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
private static PlayerBehavior instance = null;
    public static PlayerBehavior Instance => instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(gameObject);
        }
    }
    void Atk()
    {

    }
}
