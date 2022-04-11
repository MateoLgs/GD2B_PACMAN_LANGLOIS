using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{

    public void ChangeToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    void Update()
    {
        
    }
}
