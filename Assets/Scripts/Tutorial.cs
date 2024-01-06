using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject timeCircle;
    [SerializeField] GameObject tutorial;
    PlayerMovement player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); 
    }

    private void Start()
    {
        timeCircle.SetActive(false);
        tutorial.SetActive(true);
    }

    public void DisableTutorial()
    {
        tutorial.SetActive(false);
        timeCircle.SetActive(true);
        player.NotTutorial();
    }
}
