
using UnityEngine;
using UnityEngine.UI;

public class InForMission2 : MonoBehaviour
{
    public static InForMission2 Instance { get; private set; }
    public Dialog dialog;
    [SerializeField] GameObject _Mission;
    int zomebieDie = 0;
    [SerializeField] Text _MissionName;
    public bool _doneMission2 = false;
    private void Awake()
    {
        Instance= this;
    }
    private void Update()
    {
        CompleteMiss2();
      

    }
    void CompleteMiss2()
    {
        if (_doneMission2)
        {
            _MissionName.text = "Mission complete";
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
            _doneMission2 = true;
        }
        _MissionName.text = "Items:" + zomebieDie;
    }
    public bool DoneMission()
    {
        if (_doneMission2 == true)
            return true;

        return false;
    }
}
