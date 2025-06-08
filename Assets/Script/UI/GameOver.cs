using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    Image _image;
    void OnEnable()
    {
        _image = this.transform.GetComponent<Image>();
        _image.color = new Color(0, 0, 0, 0);

    }
    void Update()
    {
        _image.color = new Color(0,0,0,_image.color.a+Time.deltaTime) ;
    }
}
