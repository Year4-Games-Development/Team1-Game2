using UnityEngine;
using System.Collections;
using System.Reflection;
using System;
using UnityEditor;

public class PlayerController : MonoBehaviour {


    private PlayerControllerNonMono playerControllerNonMono = new PlayerControllerNonMono();

    public Square[,] array;

    public void Start () {
        playerControllerNonMono.MyStart();
        array = playerControllerNonMono.array;

	}

    public void Update() {
        playerControllerNonMono.MyUpdate();
    }

}
