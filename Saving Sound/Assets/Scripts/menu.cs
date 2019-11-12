using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour{
    public string scene;
    private bool loadLock;

    void Start(){

    }

    void Update(){
        if(Input.GetMouseButtonDown(0) && !loadLock){
            LoadScene();
        }
    }

    void LoadScene(){
        loadLock = true;
        Application.LoadLevel(scene);
    }
}
