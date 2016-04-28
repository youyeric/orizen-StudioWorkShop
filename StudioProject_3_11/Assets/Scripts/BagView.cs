using UnityEngine;
using System.Collections;

public class BagView : MonoBehaviour {

    // Use this for initialization
    BagController bgcontroll;
    UICreator ui;
	void Start () {
        ui = new UICreator(5);
        GameObject cardAlb = ui.createPanel("cardAlbum", this.gameObject.transform,400, 450, -200, 50, "tileEdge");
        ui.createText("cardAlbumText", cardAlb.gameObject.transform, 0, 190, 50, 50, "牌組", 18, Color.white);
        GameObject cardbag = ui.createPanel("cardInBag", this.gameObject.transform, 400, 450, 200, 50, "tileEdge");
        ui.createText("cardInBagText", cardbag.gameObject.transform, 0, 190, 50, 50, "牌庫", 18, Color.white);
        bgcontroll = new BagController(ui, cardbag.gameObject.transform, cardAlb.gameObject.transform, new MyCard());
        //儲存button
        //加入排組button setActive(false);
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void initial(Transform g) {
        foreach(Transform child in g)
        {
            if (!(child.gameObject.name.Equals("nextPage") || child.gameObject.name.Equals("prePage") || child.gameObject.name.Equals("cardInBagText") || child.gameObject.Equals("cardAlbumText")))
            {
                Destroy(child.gameObject);
            }
            
        }
    }
}
