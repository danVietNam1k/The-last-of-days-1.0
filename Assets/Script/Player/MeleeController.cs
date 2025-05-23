using UnityEngine;

public class MeleeController : MonoBehaviour
{
    Animator _actMelee;
    void Start()
    {
        _actMelee = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
            _actMelee.SetBool(CONSTANT.meleeATK, true);
        else 
            _actMelee.SetBool(CONSTANT.meleeATK, false); 


    }
}
