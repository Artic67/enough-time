using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Threading;
using UnityEngine;

public class Rewind : MonoBehaviour
{
    GameObject[] BGs;
    GameObject[] trees;
    GameObject timeCircle;
    private bool r_WasClicked;

    private Animator anim;

    [SerializeField] private float timeToNextStage = 15.0f;
    [SerializeField] private int firstStage = 1;
    [SerializeField] private int lastStage = 3;
    private float time;
    public int stage = 1;

    PlayerMovement player;

    private void Awake()
    {
        time = timeToNextStage;
        anim = GetComponent<Animator>();
        trees = GameObject.FindGameObjectsWithTag("Tree");
        BGs = GameObject.FindGameObjectsWithTag("BG");
        timeCircle = GameObject.FindGameObjectWithTag("TimeCircle");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        anim.SetInteger("Stage", firstStage);
    }

    private void Update()
    {
        print(time);

        if (time <= 0)
        {
            stage++;
            time = timeToNextStage;
            anim.SetInteger("Stage", anim.GetInteger("Stage") + 1);
        }

        if (stage > lastStage)
        {
            player.Die();
        }

        if (Input.GetKey(KeyCode.R) && player.GetNotTutorial() && player.GetIsAlive())
        {
            // Timer
            time -= Time.deltaTime;

            if (!r_WasClicked)
            {
                foreach (GameObject bg in BGs)
                {
                    bg.GetComponent<BG>().Rewind();
                }

                foreach (GameObject tree in trees)
                {
                    tree.GetComponent<Tree>().Rewind();
                }

                timeCircle.GetComponent<TimeCircle>().Rewind();

                r_WasClicked = true;
            }
        }
        else
        {
            foreach (GameObject bg in BGs)
            {
                bg.GetComponent<BG>().Rerewind();
            }

            foreach (GameObject tree in trees)
            {
                tree.GetComponent<Tree>().Rerewind();
            }

            timeCircle.GetComponent<TimeCircle>().Rerewind();

            r_WasClicked = false;
        }
        
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        stage = data.stage;
    }
}
