using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

	
	private static bool cameraExists;

	// Use this for initialization
	void Start () {
		
	//stops duplication of camera 
		if (!cameraExists) {
			cameraExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}
        
	}




	
	// Update is called once per frame
	void FixedUpdate () {

	}


}