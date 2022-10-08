using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public float volume;
    public int resIndex;
    public int muted;

    public SaveData(float volume, int resIndex, int muted)
    {
        this.volume = volume;
        this.resIndex = resIndex;
        this.muted = muted;
    }
}
