using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public bool cursorVisible;

    private void Awake()
    {
        Cursor.visible = cursorVisible;
    }
}
