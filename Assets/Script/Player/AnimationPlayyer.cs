using UnityEngine;


public class AnimationPlayyer : MonoBehaviour
{
    Animator _animPlayer;
   Rigidbody2D _rb;
    void Start()
    {
        _animPlayer = GetComponent<Animator>();
        _rb = this.transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_rb.linearVelocityX != 0 || _rb.linearVelocityY != 0)
        {
            _animPlayer.SetFloat(CONSTANT.PlayerRun, 1);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _animPlayer.SetFloat(CONSTANT.Walking, 1);
            }
            else _animPlayer.SetFloat(CONSTANT.Walking, 0);
        }
        else if(_rb.linearVelocityX ==0)
            _animPlayer.SetFloat(CONSTANT.PlayerRun, 0);


    }
 
    
}
