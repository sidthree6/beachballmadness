using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachBallShadow : MonoBehaviour {

    [Range(0.0f,1.0f)]
    public float AlphaValue = 0.6f;

	// Use this for initialization
	void Start () {

        SetAlpha(AlphaValue);

    }

    public void SetAlpha(float alpha)
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = alpha;
        GetComponent<SpriteRenderer>().color = tmp;
    }

    public void SetSize(float size)
    {
        transform.localScale = new Vector3(size, size, 0);
    }

    public float GetAlpha()
    {
        return AlphaValue;
    }
}
