using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BadEndScreen : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
}
