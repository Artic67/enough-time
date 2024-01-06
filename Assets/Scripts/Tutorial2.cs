using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial2 : MonoBehaviour
{
    [SerializeField] GameObject timeCircle;
    [SerializeField] GameObject tutorial;
    PlayerMovement player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    public void DisableTutorial()
    {
        tutorial.SetActive(false);
        timeCircle.SetActive(true);
        player.NotTutorial();
    }
}
