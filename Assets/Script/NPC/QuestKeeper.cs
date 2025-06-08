using NUnit.Framework;
using System.Collections.Generic;

using UnityEngine;

public class QuestKeeper : MonoBehaviour 
{
    [SerializeField] GameObject _isDialog, _isDialog2, _isDialog3, _Dialog;
    [SerializeField] bool _checkIsTriger = false;
  
    int _questId = 0;
   
    private void Update()
    {
       
        Interact();
    }
    void TakeMission()
    {
        _questId++;
        MissionManager.Instance.NextMission(_questId);
    }
    void Interact()
    {
        if (_isDialog.activeSelf) return;
        if (_checkIsTriger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switch (_questId)
                {
                    case 0:
                        _isDialog.SetActive(true);
                        _Dialog.SetActive(true);
                        TakeMission();
                        break;
                    case 1: 
                        if(MissionManager.Instance.CheckStateMission1() == true)
                        {
                            _isDialog2.SetActive(true);
                            _Dialog.SetActive(true);
                            TakeMission();
                        }
                        break;
                    case 2:
                        if (chest.Instance.CheckStateMissionChest() == true)
                        {
                            _isDialog3.SetActive(true);
                            _Dialog.SetActive(true);
                        }
                        break;       
                }
            }
        }
        }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(CONSTANT.Player))
            _checkIsTriger = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(CONSTANT.Player))
            _checkIsTriger = false;
    }

}
