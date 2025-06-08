using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InForMission : MonoBehaviour 
{
    public static InForMission Instance { get; private set; }
   public Dialog dialog;
    [SerializeField] GameObject _Mission;
    int zomebieDie = 0;
    [SerializeField] Text _MissionName;
    public bool _doneMission = false;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        CompleteMiss1();
    }
    void CompleteMiss1()
    {
        if (_doneMission)
        {
            _MissionName.text = "kill zombie complete!";
            return;
        }
        zomebieDie = _Mission.transform.childCount;
        foreach (Transform child in _Mission.transform)
        {
            if (!child.gameObject.activeSelf)
                zomebieDie--;
        }
        if (zomebieDie == 0)
        {
            _doneMission = true;
        }
        _MissionName.text = "Zombie alive:" + zomebieDie;
    }
    public bool DoneMission()
    {
        if (_doneMission == true)
            return true;

        return false;
    }

}
