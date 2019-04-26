using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityARInterface;
using UnityEngine.SceneManagement;

public class placeMapScript : MonoBehaviour {

	public Button StartGameBtn;
	public Button PlaceGameObjectBtn;
	public Button PlaceNewBtn;
	private ARPointCloudVisualizer ARPointCloudVisualizer;
	private ARPlaneVisualizer ARPlaneVisualizer;


	public void onClickPlaceGameObject ()
	{
		var planes = GameObject.FindGameObjectsWithTag ("planeTag");
		var particles = GameObject.FindGameObjectsWithTag ("particleTag");

		foreach (var plane in planes) 
		{
			Destroy (plane);
		}

		foreach (var particle in particles) 
		{
			Destroy (particle);
		}

		ARPointCloudVisualizer = GameObject.Find ("AR Root").GetComponent<ARPointCloudVisualizer> ();
		ARPlaneVisualizer = GameObject.Find ("AR Root").GetComponent<ARPlaneVisualizer> ();

		Destroy (ARPointCloudVisualizer);
		Destroy (ARPlaneVisualizer);

		StartGameBtn.gameObject.SetActive (true);
		PlaceNewBtn.gameObject.SetActive (true);
		PlaceGameObjectBtn.gameObject.SetActive (false);
	}

	public void onClickPlaceNew ()
	{
		SceneManager.LoadScene ("MultiplayerTankGame");
	}

}
