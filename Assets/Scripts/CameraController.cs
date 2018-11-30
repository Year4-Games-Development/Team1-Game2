using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

	
	private static bool cameraExists;

	// Use this for initialization
	void Start () {
		Debug.Log("CameraController");
	//stops duplication of camera 
		if (!cameraExists) {
			cameraExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}


		//create array map
		Model model = new Model(10,10);
		//display in console
		
        Spell spell = new Spell("spell 1", 100, 20, "down", 2);
        spell.showSpell(model.array);
        model.DisplayArrayDebug();
    }




	
	// Update is called once per frame
	void FixedUpdate () {

	}


}