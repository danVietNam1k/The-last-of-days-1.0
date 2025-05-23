using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    Rigidbody2D _rb;
    Vector3 _movement = Vector3.zero;
    [SerializeField] float _speedMove = 1f;

    SpriteRenderer _playerRenderer;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerRenderer = GetComponent<SpriteRenderer>();


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
}
