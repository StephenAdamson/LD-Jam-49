using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    private Camera cam;

    private Vector2 mousePos = new Vector2();   // Point on screenspace to take mouse position from
    public Vector3 point = new Vector3();      // Point in worldspace to map to 

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void OnGUI()
    {
        Event currentEvent = Event.current;
        // Get mouse position
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        //EOGet mouse position

        //Convert
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        //Debug
        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
        //EODebug

        // Set sprite location
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }

    public Vector3 getMousePosition()
    {
        return point;
    }
}
