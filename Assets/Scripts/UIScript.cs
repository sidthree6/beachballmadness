using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour {

    private TMP_Text _Score;
    private GameObject _Text;

    // Use this for initialization
    void Awake () {
        _Score = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TMP_Text>();
        _Text = GameObject.FindGameObjectWithTag("CText");
    }
	
	public void SetScoreText(int text)
    {
        _Score.SetText(""+text);
    }

    public void HideShowText(bool toHide)
    {
        _Text.SetActive(toHide);
    }
}
