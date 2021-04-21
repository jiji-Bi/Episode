using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sucess : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip Click;
    public static Sucess SucessInstance;
    private void Awake()
    {
        if (SucessInstance != null && SucessInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        SucessInstance = this;
        DontDestroyOnLoad(this);
    }
}
