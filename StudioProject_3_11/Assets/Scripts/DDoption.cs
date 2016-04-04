using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class DDoption : MonoBehaviour {
    public Dropdown dd;
    public string[] options;
	void Start () {
        Text labelText = GameObject.Find("DOText").GetComponent<Text>();
        labelText.text = options[0];
        foreach (string optionText in options)
        {
            dd.options.Add(new Dropdown.OptionData(optionText));
        }
    }
}
