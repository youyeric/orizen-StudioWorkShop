using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    //public GameObject panel;
    void Awake()
    {

        CanvasScaler canvasScaler = GetComponent<CanvasScaler>();

        float screenWidthScale = Screen.width / canvasScaler.referenceResolution.x;
        float screenHeightScale = Screen.height / canvasScaler.referenceResolution.y;

        canvasScaler.matchWidthOrHeight = screenWidthScale > screenHeightScale ? 1 : 0;
    }
    public void enterPlayScene()
    {
        Application.LoadLevel(1);
    }
    public void selectOne()
    {
        Application.LoadLevel(0);
    }
}
