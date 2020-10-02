using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMain:MonoBehaviour
{
    void Start() {
        Debug.Log("START!");
        SOUND_MNG.Init();
    }

    private void Update() {
        if(Input.GetKeyDown("z")){
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
