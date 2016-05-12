using UnityEngine;
using System.Collections;

public class TestFirebase : MonoBehaviour {
    IFirebase root;
	// Use this for initialization
	void Awake () {
        root = Firebase.CreateNew("https://orizenstudioworkshop.firebaseio.com/");

	}
	
	// Update is called once per frame
    void OnEnable() {
        root.ChildAdded += rootChildAdded;
    }
    void OnDisable() {
        root.ChildAdded -= rootChildAdded;
    }
    void rootChildAdded(object sender, FirebaseChangedEventArgs e)
    {
        Debug.Log("RootAction: " + e.DataSnapshot.Key);
    }
}
