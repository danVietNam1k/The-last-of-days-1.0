using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowDialogCutScene : MonoBehaviour
{
    [SerializeField] Dialog dialog;
    private void Awake()
    {
        DialogManagerr.Instance.ShowDialog(dialog);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (DialogManagerr.Instance.CheckEndDialog(dialog) == true) 
            {
                SceneManager.LoadScene(CONSTANT.MainGame);
            } else
            {
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
        Interact();
        yield return new WaitForSeconds(2);
        
    }
}
