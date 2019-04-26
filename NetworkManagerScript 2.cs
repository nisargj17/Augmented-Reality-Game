using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerScript : MonoBehaviour {


	public Text TextInfos;
	public Transform SpawnPoint1;
	public Transform SpawnPoint2;
	public GameObject[] players;
	private bool gameStarted = false;
	Text TxtHealth;
	Text TxtHealthOther;
	Text newGameText;


	// Use this for initialization
	void Start () {

		PhotonNetwork.ConnectUsingSettings ("v01");
		newGameText = GameObject.Find ("newGameText").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (PhotonNetwork.connectionStateDetailed.ToString () != "Joined") {
			TextInfos.text = PhotonNetwork.connectionStateDetailed.ToString ();
		} else {
			TextInfos.text = "Connected to " + PhotonNetwork.room.name + " Player(s) Online: " + PhotonNetwork.room.PlayerCount;
		}


		players = GameObject.FindGameObjectsWithTag ("Player");

		if (players.Length == 2) 
		{
			gameStarted = true;
		}

		if (gameStarted) 
		{

			if (players.Length <= 1) 
			{
				for (int i = 0; i < players.Length; i++) 
				{
					Destroy (players [i]);
					StartCoroutine (startNewRound ());
					gameStarted = false;

					TxtHealth = GameObject.Find ("TxtHealth").GetComponent<Text> ();
					TxtHealthOther = GameObject.Find ("TxtHealthOther").GetComponent<Text> ();
					TxtHealth.text = "ME 100%";
					TxtHealthOther.text = "ME 100%";

				}
			}
		}
	}



	IEnumerator startNewRound()
	{
		newGameText.text = "3";
		yield return new WaitForSeconds (1f);
		newGameText.text = "2";
		yield return new WaitForSeconds (1f);
		newGameText.text = "1";
		yield return new WaitForSeconds (1f);
		newGameText.text = "GO";
		yield return new WaitForSeconds (1f);
		newGameText.text = " ";
		 

		int randomX = Random.Range (-5, +5);
		PhotonNetwork.Instantiate ("Tank", new Vector3 (randomX, SpawnPoint1.transform.position.y, SpawnPoint1.transform.position.z), Quaternion.identity, 0);
	}
	


	void OnConnectedToMaster()
	{
		Debug.Log ("Connected with Master");
		PhotonNetwork.JoinLobby ();
	}

	void OnJoinedLobby()
	{
		RoomOptions MyRoomOptions = new RoomOptions ();
		MyRoomOptions.MaxPlayers = 2;
		PhotonNetwork.JoinOrCreateRoom ("Room1", MyRoomOptions, TypedLobby.Default);

		Debug.Log ("Connected with Lobby");

	}

	void OnJoinedRoom()
	{

		if (PhotonNetwork.playerList.Length > 1) {
			StartCoroutine (SpawnMyPlayer ());
		} 
		else 
		{
			StartCoroutine (SpawnMyPlayer2 ());
		}
	}

	IEnumerator SpawnMyPlayer()
	{
		yield return new WaitForSeconds (1f);
		GameObject MyPlayer = PhotonNetwork.Instantiate ("Tank", SpawnPoint1.position, Quaternion.identity, 0) as GameObject;

	}

	IEnumerator SpawnMyPlayer2()
	{
		yield return new WaitForSeconds (1);
		GameObject MyPlayer = PhotonNetwork.Instantiate ("Tank", SpawnPoint2.position, Quaternion.identity, 0) as GameObject;

	}
		
}
