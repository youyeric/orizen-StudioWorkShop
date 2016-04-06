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
        ui.createButton("return", this.gameObject.transform, new Vector2(350, -225), new Vector2(50 , 25), "返回",10, Color.white, "button", delegate { GameObject.Find("GameController").gameObject.GetComponent<LoadScene>().returnToMain(this.gameObject); });
        bgcontroll = new BagController(ui, cardbag.gameObject.transform, cardAlb.gameObject.transform, new MyCard("bag.csv"));
        
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
