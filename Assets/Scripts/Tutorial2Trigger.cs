using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial2Trigger : MonoBehaviour
{
    [SerializeField] GameObject timeCircle;
    [SerializeField] GameObject tutorial;
    PlayerMovement player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            timeCircle.SetActive(false);
            tutorial.SetActive(true);
            player.Tutorial();
        }
        
    }
}
