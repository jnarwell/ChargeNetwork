using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_script : MonoBehaviour
{
    public void Start_Program()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Start_Scene") SceneManager.LoadScene("Instruction_Scene");
        if (sceneName == "Instruction_Scene") SceneManager.LoadScene("Main_Scene");
    }
}
