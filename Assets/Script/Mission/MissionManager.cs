using UnityEngine;

public class MissionManager : MonoBehaviour
{
    private static MissionManager instance = null;
    public static MissionManager Instance => instance;
    [SerializeField] int _positionMission = 0;
    [SerializeField] GameObject Mission1;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }
        if (instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }
    public void NextMission(int IdQuest)
    {
        _positionMission = IdQuest;
        ThisMission();


    }
    public bool CheckStateMission1()
    {
        if(InForMission.Instance.DoneMission() == true &&
           InForMission2.Instance.DoneMission() == true)
            return true;
        return false;
    }
    public bool CheckStateMission2()
    {
        if (chest.Instance.CheckStateMissionChest() == true)
            return true;
        return false;
    }
    public void ThisMission()
    {
        switch (_positionMission)
        {
            case 0: 
                return;
            case 1:
                this.transform.GetChild(0).gameObject.SetActive(true);
                EmotionNPC.Instance.SetEmotionTrue(true);
                break;
            case 2:
                this.transform.GetChild(0).gameObject.SetActive(false);
                this.transform.GetChild(1).gameObject.SetActive(true);
                break ;
            case 3:
                this.transform.GetChild(1).gameObject.SetActive(false);
                break;
        }

    }

}
