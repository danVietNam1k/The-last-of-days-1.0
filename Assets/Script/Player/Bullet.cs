using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _speed;
  
   
    private void OnEnable()
    {
        AudioManager.Instance.PlayAuShoot();
        StartCoroutine(DeactiveAffterTime());
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
            _rb.linearVelocity = this.transform.right * -_speed;
    }
    IEnumerator DeactiveAffterTime()
    {   
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            this.gameObject.SetActive(false);
        }
    }

}
