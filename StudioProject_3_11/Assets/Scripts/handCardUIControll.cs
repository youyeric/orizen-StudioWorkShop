using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class handCardUIControll : MonoBehaviour {
    private string CardImagePath = System.Environment.CurrentDirectory + "/Asset/Image/FormChange-SD27-JP-C.png";
    private UICreator ui;
    private int handCardposition;

    public handCardUIControll()
    {
        ui = new UICreator(5);
        this.handCardposition = 0;
    }
}
