using UnityEngine;
using System.Collections;

public class AnimateTexture : MonoBehaviour {
    public Vector2 Delta;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Material mat = this.gameObject.GetComponent<MeshRenderer>().material;
        float newX = mat.GetTextureOffset("_MainTex").x + Delta.x;
        float newY = mat.GetTextureOffset("_MainTex").y + Delta.y;
        mat.SetTextureOffset("_MainTex", new Vector2(newX, newY));
	}
}
