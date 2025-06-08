using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Rigidbody2D _rb;
    Vector3 _movement = Vector3.zero;
    [SerializeField] float _speedMove = 1f;
    [SerializeField] int _hpMax = 100, _hp;
    SpriteRenderer _playerRenderer;
    [SerializeField] Image _HpBar;
    [SerializeField] GameObject _gameOver;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerRenderer = GetComponent<SpriteRenderer>();
        _hp = _hpMax;
    }

    // Update is called once per frame
    void Update()
    {
        MovingPlayer();
        PlayerLookAtTheMouse();
    }
    private void FixedUpdate()
    {   if( Input.GetKey(KeyCode.LeftShift) )
            _rb.linearVelocity = _movement.normalized * _speedMove*3;
        else _rb.linearVelocity = _movement.normalized * _speedMove;
    }

    void MovingPlayer()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    void PlayerLookAtTheMouse()
    {
        Vector3 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerPosition = this.transform.position;
        if (playerPosition.x - posMouse.x > 0)
        {
            this.transform.localScale = new Vector3(-1,1,1);
        }
        if (playerPosition.x - posMouse.x < 0)
        {
            this.transform.localScale =  new Vector3(1,1, 1);
        }
    }
    public void TakeDame(int dame)
    {
        _hp -= dame;
        if (_hp < 0)
        {
            this.gameObject.SetActive(false);
            _gameOver.gameObject.SetActive(true);

        }
        _HpBar.fillAmount = _hp/100f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("atkEnemy"))
        {
            TakeDame(40);
            //Debug.Log(_hp);
        }
    }

}
