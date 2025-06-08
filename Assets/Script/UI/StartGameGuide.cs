using UnityEngine;

public class StartGameGuide : MonoBehaviour
{
    void Update()
    {
        Time.timeScale = 0f;
        if(Input.GetKeyDown(KeyCode.E))
        {
            Time.timeScale = 1f;
            Destroy(this.gameObject);   
        }    
    }
}
