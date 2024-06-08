using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 cursorScreenPos = Input.mousePosition;
        cursorScreenPos.z = 10f;
        Vector3 cursorWorldPos = Camera.main.ScreenToWorldPoint(cursorScreenPos);
        transform.position = cursorWorldPos;
    }
}
