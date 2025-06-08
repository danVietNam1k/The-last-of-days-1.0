using UnityEngine;

public class Funtion1
{  
    public static float AngleThis2Mouse(Vector3 _this)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookFollowingMouse = _this - pos;
        float angle = Mathf.Atan2(lookFollowingMouse.y, lookFollowingMouse.x) * Mathf.Rad2Deg;

        return angle;

    }
 
}
