using UnityEngine;
using System.Collections;

public class DragPipe : MonoBehaviour
{
    bool mouseDown;
    void Awake()
    {
        mouseDown = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(this);
        }
    }
}
