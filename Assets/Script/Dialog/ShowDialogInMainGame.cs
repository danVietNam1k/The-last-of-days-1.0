using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowDialogInMainGame : MonoBehaviour
{
    [SerializeField] Dialog dialog;
    [SerializeField] GameObject Boxtext;
    bool _waitText = true;
    
    private void OnEnable()
    {
        DialogManagerr.Instance.ShowDialog(dialog);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& _waitText)
        {
            if (DialogManagerr.Instance.CheckEndDialog(dialog) == true) 
            {
                Boxtext.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
            else
            {
                Interact();
                
                StartCoroutine(WaitText());
            }
        }
    }
    public void Interact()
    {
        DialogManagerr.Instance.ShowDialog(dialog);
    }
    IEnumerator WaitText()
    {
        _waitText = false;

        yield return new WaitForSeconds(1);
        _waitText =true;
    }
}
