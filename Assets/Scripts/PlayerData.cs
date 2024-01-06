using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int stage;

    public PlayerData (Rewind player)
    {
        stage = player.stage;
    }
}
