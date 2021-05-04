using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Player : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle,walking;
    public string currentState;
    public float speed;
    public float movement;
    private Rigidbody2D rigidbody;
    public string currentAnimation;
        // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        currentState = "Idle";
        SetCharacterState(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    //sets character animation requested
    //set animation is async nativ method form spine runtime not recursive 
    public void SetAnimation(AnimationReferenceAsset animation, bool loop,float timescale)
    {
        if(animation.name.Equals(currentAnimation))
        { return; }
        skeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timescale;
        currentAnimation = animation.name;
    }
    public void SetCharacterState(string state)
    {
        if (state.Equals("Idle"))
        {
            SetAnimation(idle, true, 1f);
        }
        else if (state.Equals("Walking"))
        {
            SetAnimation(walking, true, 1f);
        }

    }
    public void Move()
    {
        movement = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(movement * speed, rigidbody.velocity.y);
        if (movement != 0)
        { SetCharacterState("Walking"); }
        else
        { SetCharacterState("Idle"); }
    }
}
