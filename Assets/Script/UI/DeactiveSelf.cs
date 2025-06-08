using UnityEngine;

public class DeactiveSelf : MonoBehaviour
{
    [SerializeField] GameObject _scene2;
    void Start()
    {
        this.transform.parent.gameObject.SetActive(false);
        _scene2.gameObject.SetActive(true);
    }
}
