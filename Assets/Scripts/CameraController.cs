using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {


    private GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;
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


		//create array map
		Model model = new Model(10,10);
		//display in console
		
        Spell spell = new Spell("spell 1", 100, 20, Orientation.Down, 2, 0);
        spell.showSpell(model);
        //model.DisplayArrayDebug();
    }

    void FixedUpdate()
    {



    }





}