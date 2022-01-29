using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDecorator : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursorArrow;

    void Start()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
}
