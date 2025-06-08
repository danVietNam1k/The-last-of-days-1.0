using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PressE : MonoBehaviour
{
   [SerializeField] Text _text;
    private void Start()
    {
       StartCoroutine(WaitText());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _text.transform.gameObject.SetActive(false);
            StartCoroutine(WaitText());
        }

    }
    IEnumerator WaitText()
    {
        yield return new WaitForSeconds(1);
        _text.transform.gameObject.SetActive(true);
        _text.text = "Press E";
    }
}
