using UnityEngine;
using System.Collections;

public class BattleCamera : MonoBehaviour {
    public float moveSY = 1.0f;
    private float minPY = 0;
    private float maxPY = 13.1f;
    private Transform tf;
    private Camera cam;
    void Start()
    {
        tf = transform;
        cam = Camera.main;
    }
    void Update()
    {
        cam.transform.position = new Vector3(
            cam.transform.position.x,
            Mathf.Clamp(cam.transform.position.y, minPY, maxPY),
            cam.transform.position.z
        );
        Touch[] touches = Input.touches;
        if (touches.Length >= 1)
        {
            if (touches.Length == 1)
            {
                if(touches[0].phase == TouchPhase.Moved)
                {
                    Vector2 delta = touches[0].deltaPosition;
                    float positionY = delta.y * moveSY * Time.deltaTime;
                    positionY = positionY * -1;
                    cam.transform.position += new Vector3(0, positionY, 0);
                }
            }
        }
    }
}
