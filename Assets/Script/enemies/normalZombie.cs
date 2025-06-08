using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class normalZombie : BehaviorEnemies
{
    [SerializeField] float _speedMove = 2f;
    [SerializeField] int _hpmax = 100, _atkDamge = 30, _hp;
    Rigidbody2D _rb;
    bool _nextStep = false, _deadState = false, _checkPlayer = false;
    [SerializeField] Transform _spawHere ;
    Vector3 newPos;
    Animator _animator;
    Transform _target;
    private void OnEnable()
    {
        _hp =_hpmax;
        _deadState =false;
     
    }
    void Start()
    {
        _animator = GetComponent<Animator>();
       _rb = GetComponent<Rigidbody2D>();
        _spawHere = this.transform.parent.GetComponent<Transform>();

        StartCoroutine(NextStepMoving());
        _target = GameObject.Find(CONSTANT.Player).transform;
    }
    void Update()
    {
        //Debug.LogError(_checkPlayer);
        Anim();
    }
    private void FixedUpdate()
    {
        if (_deadState)
        {
            _rb.linearVelocity = Vector3.zero;

            return;
        }
        nextMoving();
    }
    void Anim()
    {
        if (_deadState)
        {
            _animator.SetBool(CONSTANT.Walking, false);
            _animator.SetBool(CONSTANT.Atk, false);
            _animator.SetBool(CONSTANT.Dead, true);
            StartCoroutine(WaitAnimationDead());
        }
        else
        {
            if (_rb.linearVelocity.x != 0)
            {
                _animator.SetBool(CONSTANT.Walking, true);
                if (_rb.linearVelocity.x > 0)
                {
                    this.transform.localScale = Vector3.one;
                }
                else
                    this.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (Vector3.Distance(this.transform.position, _target.position) < 1f)
            {
                _animator.SetBool(CONSTANT.Atk, true);
                _animator.SetBool(CONSTANT.Walking, false);
                if (_target.position.x - this.transform.position.x > 0)
                {
                    this.transform.localScale = Vector3.one;
                }
                else
                    this.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                _animator.SetBool(CONSTANT.Atk, false);
                _animator.SetBool(CONSTANT.Walking, false);
            }
        }
        
    }
    void nextMoving()
    {
        if (_checkPlayer)
        {
            if (Vector3.Distance(this.transform.position, _target.position) < 1f)
                _rb.linearVelocity = Vector3.zero;
            else _rb.linearVelocity = (_target.position - this.transform.position).normalized * _speedMove;
        }
        else
        {
            if (_nextStep)
            {
                _rb.linearVelocity = (newPos - this.transform.position).normalized * _speedMove;
            }
            if (Vector3.Distance(newPos, this.transform.position) < 0.2f)
            {
                _rb.linearVelocity = Vector2.zero;
                _nextStep = false;
            }
        }
       
        //Debug.Log(newPos);
    }
    #region Waiting
    IEnumerator NextStepMoving()
    {
        while(true) { 
            yield return new WaitForSeconds(10);
            newPos = BehaviorEnemies.RamdomTargetMove(_spawHere.position);
            _nextStep = true;
        }
    }
    IEnumerator WaitAnimationDead()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }
    #endregion
    public void Takedame(int dame) {
    _hp -= dame;
        if (_hp <= 0)
        {
            _deadState = true;
            AudioManager.Instance.PlayAuZombie();
        }
    }
    public void PositionTakeDame(bool dameHead,bool dameBody) {  
    if (!dameBody && dameHead)
        { Takedame(100);
            Debug.Log("Headshot");
        }
    else if (dameBody && !dameHead)
        { Takedame(40); }
    else 
            Takedame(60);
    }
    public void OnPlayerDetected(bool detected)
    {
        if (detected)
        {
            _checkPlayer = true;
        }
        else
        {
            _checkPlayer = false;
        }
    }

}   
