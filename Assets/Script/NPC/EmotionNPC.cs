using UnityEngine;

public class EmotionNPC : MonoBehaviour
{
    public static EmotionNPC Instance { get; private set; }
    
    Animator Animation;
    void Awake()
    {
        Animation = GetComponent<Animator>();
        Instance = this;
    }

    public void SetEmotionTrue(bool _bool)
    {
        Debug.Log("set emotion");
        Animation.SetBool(CONSTANT.EmotionOnDuty, _bool);
       
    }

}
