using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {
    public Vector3 Delta;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Translate(Delta);
	}
}
