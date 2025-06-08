using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D _cursorNormal, _cursorAim, _cursorReloading;

    [SerializeField] Vector2 _cursorPosition = new Vector2(16, 48);
    bool _stateCursor = false;
    void Start()
    {
        Cursor.SetCursor(_cursorNormal, _cursorPosition, CursorMode.Auto);
    }
    void Update()
    {
        StateOfCursor();
    }
    void StateOfCursor()
    {
        if (!_stateCursor && Input.GetMouseButton(1))
        {
            Cursor.SetCursor(_cursorAim, _cursorPosition, CursorMode.Auto);

        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            _stateCursor = true;
            Cursor.SetCursor(_cursorReloading, _cursorPosition, CursorMode.Auto);
            StartCoroutine(StateCursor())
            ;
        }
        else if (!_stateCursor && !Input.GetMouseButton(1)) 
            Cursor.SetCursor(_cursorNormal, _cursorPosition, CursorMode.Auto);
    }
    IEnumerator StateCursor()
    {
        yield return new WaitForSeconds(1);
        _stateCursor = false;

    }
}
    

    

