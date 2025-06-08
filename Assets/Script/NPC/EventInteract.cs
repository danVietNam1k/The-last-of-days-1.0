using UnityEngine;

public class EventInteract : MonoBehaviour
{
    [SerializeField] GameObject _isDialog, _Dialog;
    [SerializeField] bool _checkIsTriger =false;
    private void Update()
    {
        Interact();
    }
    void Interact()
    {
        if (_isDialog.activeSelf) return;
        if (_checkIsTriger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isDialog.SetActive(true);
                _Dialog.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(CONSTANT.Player))
            _checkIsTriger = true;
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag(CONSTANT.Player))
            _checkIsTriger = false;
    }
}
