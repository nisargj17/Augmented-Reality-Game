using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasOnTankScript : MonoBehaviour {

	public Text playerName;
	PhotonView view;

	// Use this for initialization
	void Start () {

		view = GetComponent<PhotonView> ();

		if (view.isMine) {
			playerName.text = "ME";
			playerName.color = new Color (1, 0.2f, 0.016f, 1); 
		} 
		else 
		{
			playerName.text = "OTHER";
			playerName.color = new Color (1, 0.92f, 0.016f, 1); 
		}
		
	}
}
