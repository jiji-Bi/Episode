using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScript : MonoBehaviour
{

    public static BgScript Bginstance;
    public AudioSource Audio;
    private void Awake()
    {
        if(Bginstance!=null && Bginstance!=this)
        {
            Destroy (this.gameObject);
            return;
        }
        Bginstance = this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }
}
