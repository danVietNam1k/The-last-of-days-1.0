using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManagerr : MonoBehaviour
{
    public static DialogManagerr Instance
    { get; private set; }
    [SerializeField] GameObject _dialogBox;
    [SerializeField] Text _dialogText;
    [SerializeField] float _lettersPerSecond;
    int dialogCount = 0;
    
    public void Awake()
    {
        Instance = this;
        
    }
    public void ShowDialog(Dialog dialog)
    {
        StartCoroutine(TypeDialog(dialog.Lines[dialogCount]));
       
    }
    public bool CheckEndDialog(Dialog dialog)
    {
        dialogCount++;
        if (dialogCount>= dialog.Lines.Count) {
            dialogCount = 0;
            return true;
 
        }

        return false;
    }
    public IEnumerator TypeDialog(string line)
    {
        _dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            _dialogText.text += letter;
            AudioManager.Instance.PlayAuDialog();
            yield return new WaitForSeconds(1f / _lettersPerSecond);
        }
    }
}
