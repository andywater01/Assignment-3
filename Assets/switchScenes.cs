using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchScenes : MonoBehaviour
{
    public void loadScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
