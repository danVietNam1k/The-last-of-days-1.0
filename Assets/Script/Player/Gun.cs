using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] List<GameObject> _BulletList = new List<GameObject>();
    Quaternion _ramdomQ = new Quaternion();
    LineRenderer _lazeGun;
    float _WaitTimeFire= 0;
    [SerializeField] GameObject _lazePosition;
    void Start()
    {
        _lazeGun = GetComponent<LineRenderer>();
    }

    void Update()
    {

        if (Input.GetMouseButton(1))
        {
            LazeGun();
            _lazeGun.enabled = true;
        }

        else _lazeGun.enabled = false;

        RamdomAngleTofire();
        _WaitTimeFire -= Time.deltaTime;
        if (Input.GetMouseButton(0) && _WaitTimeFire<=0f)
        {
            InstantBullet();
            _WaitTimeFire = 0.3f;
        }
    }
    GameObject InstantBullet()
    {
        foreach (GameObject obj in _BulletList) {
            if (obj.gameObject.activeSelf) continue;
            else if (!obj.gameObject.activeSelf) {
                obj.transform.position = this.transform.position;
                obj.transform.rotation = _ramdomQ;
                obj.SetActive(true);
                return obj;
            }
            
        }
        GameObject _bullet = Instantiate(_bulletPrefab, this.transform.position, _ramdomQ);
        _BulletList.Add(_bullet);
        _bullet.gameObject.SetActive(true);
        return _bullet;
    }
    void RamdomAngleTofire()
    {
        
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
           {
                _ramdomQ = this.transform.rotation;
            
           }
           else
           {
            float angle = this.transform.rotation.z;
            angle = Random.Range(angle + 0.2f, angle - 0.2f);
            
            //Debug.LogError(angle);
            //Debug.Log(this.transform.rotation);
             _ramdomQ = new Quaternion(0, 0, angle, this.transform.rotation.w);
    }
}
    void LazeGun()
    {
        Vector2 pos1 = this.transform.position;
        Vector2 pos2 = _lazePosition.transform.position;
        _lazeGun.SetPosition(0, pos1);
        _lazeGun.SetPosition(1, pos2);
    }

}
