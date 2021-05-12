using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class BackgManager : MonoBehaviour
{
    public Image blackScreen;
    public Animator blackScreenAnimator;
    public GameObject[] backgrounds;
    public GameObject currentBackground;
    //public Transform backgroundPositionMarker;
    public static BackgManager instance;
    private float transitionTime, transitionTimer;
    private bool transitioningIn, transitioningOut;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("There is more than one BackgroundManager");
        }
    }

    public void ChangeBackground(int index, float transitionTime)
    {
        if (currentBackground != null) Destroy(currentBackground);
        //TransitionOut(transitionTime);
        currentBackground = Instantiate(backgrounds[index]);
        
        currentBackground.transform.position = currentBackground.transform.position;
    }
   /* private void TransitionOut(float transitionTime)
   {
       if (transitioningOut) return;
       this.transitionTime = transitionTime / 2;
       transitionTimer = this.transitionTime;
       //   blackScreenAnimator.SetTrigger("TransitionOut");
       transitioningOut = true;
       blackScreen.raycastTarget = true;
   }
   private void TransitionIn()
   {
       if (transitioningIn) return;
       // blackScreenAnimator.SetTrigger("TransitionIn");
       transitioningOut = false;
       transitionTimer = transitionTime;
       transitioningIn = true;
       blackScreen.raycastTarget = false;
   }
   private void Update()
   {
       if (transitionTimer > 0)
       {
           transitionTimer -= Time.deltaTime;
           if (transitioningOut)
           {
               blackScreen.color = new Color(blackScreen.color.r,
                   blackScreen.color.g, blackScreen.color.b, 1 / (transitionTime * 2 / transitionTimer));
           }
           else if (transitioningIn)
           {
               blackScreen.color = new Color(blackScreen.color.r,
                 blackScreen.color.g, blackScreen.color.b, (transitionTimer / transitionTime));
           }
       }
       else
       {
           if (transitioningOut)
           {
               TransitionIn();
           }
           else if (transitioningIn)
           {
               transitioningIn = false;
           }
       }
   }*/


}
