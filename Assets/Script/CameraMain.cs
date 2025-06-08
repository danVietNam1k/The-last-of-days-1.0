using System.Collections;
using UnityEngine;


public class CameraMainPos : MonoBehaviour
{
    [SerializeField] Transform _playerTransform ;
    [SerializeField] GameObject _boss;
    bool _lookBoss= false;
    Vector3 pos;
    void Update()
    {
        if(_lookBoss == false && _boss.activeSelf)
        {
            pos = _boss.transform.position;
            pos.z = -10;
            this.transform.position = pos;
            StartCoroutine(WaitLookBoss());
            return;
        }


        pos = _playerTransform.position;
        pos.z = -10;
        this.transform.position = pos;

    }
    IEnumerator WaitLookBoss()
    {
        yield return new WaitForSeconds(2);
        _lookBoss = true;
    }
}
