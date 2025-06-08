using UnityEngine;
using UnityEngine.UI;

public class chest : MonoBehaviour
{   public static chest Instance { get; private set; }
    [SerializeField] GameObject _boss, _TimeUn;   
    [SerializeField] float _state =0;
    [SerializeField] Image _timeUnlock;
    bool _doneMission= false;
    [SerializeField] Text _nameMission;
    bool _checkPlayer = false;
    private void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        StateMissionChest();
        if (_checkPlayer && Input.GetKey(KeyCode.E))
            CallBoss();
        CheckStateMissionChest();
    }
    void CallBoss()
    {
        if(_state == 0)
        {
            _state += 1;
            _boss?.gameObject.SetActive(true);
            return;
        }    
        if(_state >=1 && !_boss.activeSelf)
        {   if(!_TimeUn.gameObject.activeSelf)
                _TimeUn.SetActive(true);
            _state += Time.deltaTime;
            TimeUnlock(); 
        }    
    }
    void TimeUnlock()
    {
        if(_TimeUn.gameObject.activeSelf)
        _timeUnlock.fillAmount = 1f * (_state- 1) / 4;
    }
    void StateMissionChest()
    {
        if(_state >= 5 && !_doneMission)
        {
            _nameMission.text += " Mission Completed";
            _doneMission = true;
            _TimeUn.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CONSTANT.Player))
    {
            _checkPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(CONSTANT.Player))
        {
            _checkPlayer = false;
        }
    }
    public bool CheckStateMissionChest()
    {   
        return _doneMission; 
    }
}
