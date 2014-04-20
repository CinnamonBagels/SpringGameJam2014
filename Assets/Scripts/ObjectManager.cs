using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

	private Lava lava;

	public void receiveLavaObject(Lava lavaObject) {
		lava = lavaObject;
	}
}
