using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Rewind()
    {
        anim.SetBool("IsRewinding", true);
    }

    public void Rerewind()
    {
        anim.SetBool("IsRewinding", false);
    }
}
