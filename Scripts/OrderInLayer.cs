using UnityEngine;
using System.Collections;

public class OrderInLayer : MonoBehaviour {

	// Use this for initialization
	private SpriteRenderer tempRend;

	void Start () {
		tempRend = GetComponent<SpriteRenderer>();
	}


	void LateUpdate () {

		SetOrderInLayer (transform.position.y);
			// (int)Camera.main.WorldToScreenPoint (tempRend.bounds.min).y * -10;
		Debug.Log (tempRend.sortingOrder);
	}

	void SetOrderInLayer (float input_y) {
		Debug.Log ("Set Order In Layer");
		float y_pos = transform.position.y;
		int orderInLayer;
		orderInLayer = (int)(y_pos * (-20));
		tempRend.sortingOrder = orderInLayer;
		Debug.Log (orderInLayer);
	}

}
