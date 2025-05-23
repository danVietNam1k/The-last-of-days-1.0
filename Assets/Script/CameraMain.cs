using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CameraMainPos : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = _playerTransform.position;
        pos.z = -10;
        this.transform.position = pos;

    }
}
