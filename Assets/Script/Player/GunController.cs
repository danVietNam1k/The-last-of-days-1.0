using System;
using UnityEngine;

public class GunController : MonoBehaviour 
{
    Transform _look;
    Animator _gunAnimator;
    
    void Start()
    {
        _look = this.transform;
        _gunAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationGun();
        LookMouse();
    }
   
    void AnimationGun()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            _gunAnimator.SetBool(CONSTANT.GunFire, true);
            _gunAnimator.SetBool(CONSTANT.GunReloading, false);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            _gunAnimator.SetBool(CONSTANT.GunFire, false);
            _gunAnimator.SetBool(CONSTANT.GunReloading, true);
        }
        else
        {
            _gunAnimator.SetBool(CONSTANT.GunFire, false);
            _gunAnimator.SetBool(CONSTANT.GunReloading, false);
           
        }
        }

    void LookMouse()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookFollowingMouse = this.transform.position - pos;
        float angle = Mathf.Atan2(lookFollowingMouse.y, lookFollowingMouse.x) * Mathf.Rad2Deg;
        Quaternion lookRotation = _look.rotation;
        lookRotation.eulerAngles = new Vector3(0, 0, angle);
        _look.rotation = lookRotation;

        if (pos.x - this.transform.position.x > 0)
        {
            this.transform.localScale = new Vector3(-1, -1, 1);
            //this.transform.GetComponent<SpriteRenderer>().flipX = true;
            //this.transform.GetComponent<SpriteRenderer>().flipY = true;

        }
        else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            //this.transform.GetComponent<SpriteRenderer>().flipX = false;
            //this.transform.GetComponent<SpriteRenderer>().flipY = false;
        }
    }
}
