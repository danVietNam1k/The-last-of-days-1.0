using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour 
{
    [SerializeField] float _speedMove = 2f;
    [SerializeField] int _hpmax = 5000, _atkDamge = 30, _hp;
    Rigidbody2D _rb;
    bool  _deadState = false;
    Vector3 newPos;
    Animator _animator;
    [SerializeField] Transform _target;
    [SerializeField] Image _hpBar;
    private void OnEnable()
    {
        _hp = _hpmax;
        _deadState = false;

    }
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _animator.SetBool(CONSTANT.Walking, true);
    }
    void Update()
    {
        Anim();
    }
    private void FixedUpdate()
    {
       
        nextMoving();
    }
    void Anim()
    {

        if (_deadState)
        {
            _animator.SetBool(CONSTANT.Atk, false);
            _animator.SetBool(CONSTANT.Dead, true);
            
            StartCoroutine(WaitAnimationDead());
        }
        else
        {
            if (_target.position.x - this.transform.position.x > 0)
            {
                this.transform.localScale = Vector3.one;
            }
            else
                this.transform.localScale = new Vector3(-1, 1, 1);

            if (Vector3.Distance(this.transform.position, _target.position) <=2f)
            {
                _animator.SetBool(CONSTANT.Atk, true);
             
            }
            else _animator.SetBool(CONSTANT.Atk, false);




        }
    }
    void nextMoving()
    {
      

        if (_deadState  || Vector3.Distance(this.transform.position, _target.position) <= 2f)
        {
            _rb.linearVelocity = Vector3.zero;
            return;
        }
            
        if (Vector3.Distance(this.transform.position, _target.position) > 2f ){
            _rb.linearVelocity = (_target.position - this.transform.position).normalized * _speedMove;
            
        }
    }
    #region Waiting
    
   
    IEnumerator WaitAnimationDead()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }
    #endregion
    public void Takedame(int dame)
    {
        _hp -= dame;
        _hpBar.fillAmount = 1f* _hp / _hpmax;
        if (_hp <= 0) 
        { AudioManager.Instance.PlayAuBoss();
            _deadState = true;
        }
            
    }

    public void PositionTakeDame(bool dameHead, bool dameBody)
    {
        if (!dameBody && dameHead)
        {
            Takedame(100);
            Debug.Log("Headshot");
        }
        else if (dameBody && !dameHead)
        { Takedame(40); }
        else
            Takedame(60);
    }

   

}
