using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handler : MonoBehaviour{ 
    public string scene;
    public Button button;
    public Button button2;
    
    void Start(){

    }

    void Update(){

    }

    public void Tutorial(string scene){
        Application.LoadLevel("Tutorial2");
    }

    public void Level1(string scene){
        Application.LoadLevel("Level1");
    }
}
