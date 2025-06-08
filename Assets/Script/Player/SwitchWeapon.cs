using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] GameObject _gun;
    [SerializeField] GameObject _melee;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (_gun.gameObject.activeSelf && !_melee.gameObject.activeSelf)
            {
                _melee.gameObject.SetActive(true);
                _gun.gameObject.SetActive(false);
            }
            else if (!_gun.gameObject.activeSelf && _melee.gameObject.activeSelf)
            {
                _melee.gameObject.SetActive(false);
                _gun.gameObject.SetActive(true);
            }


        }
    }
}
