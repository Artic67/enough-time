using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
