using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip Click;
    public static Fail FailInstance ;
    private void Awake()
    {
        if (FailInstance != null && FailInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        FailInstance = this;
        DontDestroyOnLoad(this);
    }

}
