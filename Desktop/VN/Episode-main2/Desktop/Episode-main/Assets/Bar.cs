using UnityEngine;
using DentedPixel ;
public class Bar : MonoBehaviour
{ public GameObject bar;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
         Animatebar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Animatebar()
    { LeanTween.scaleX(bar, 1,time); }
}
