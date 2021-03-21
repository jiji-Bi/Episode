using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScript : MonoBehaviour
{

    public static BgScript Bginstance;
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
}
