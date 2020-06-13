using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public GameObject particle;

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            switch(touch.phase)
            {
                case TouchPhase.Began:
                    {
                        HandleTouchBegan(touch);
                        break;
                    }
                case TouchPhase.Moved:
                    {
                        HandleTouchMoved(touch);
                        break;
                    }
            }
        }
    }

    void HandleTouchBegan(Touch touch) 
    {
        Debug.Log("Got a touch BEGAN.");
        // Construct a ray from the current touch coordinates
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        if (Physics.Raycast(ray))
        {
            // Create a particle if hit
            Instantiate(particle, transform.position, transform.rotation);
        }
    }

    void HandleTouchMoved(Touch touch)
    {
        Debug.Log(string.Format("Got a touch MOVED. {0}", touch.deltaPosition));
        transform.Rotate(0, touch.deltaPosition.y, touch.deltaPosition.x);
    }
}
