VAR energylevel = 0
VAR was_nice_to_Laura = false
EXTERNAL change_background(x)
EXTERNAL add_character(x,y) 
//EXTERNAL play_voiceline(index,pitch, volume)
//EXTERNAL finished(victory)
//EXTERNAL show_emotion(emotion)
One day, the brave adventurer started waking up feeling, a little bit weird.
hiihih
~change_background(0)
~add_character(0,2)
->waking_up
==waking_up==
* [Get up from bed] 
->after_getting_up
+ [Stay in bed a little longer]
You lazily stay in bed and regain more energy...
//~show_emotion("sad")
//play_voiceline(0,1, 50)
~energylevel++
->waking_up

==after_getting_up==
~change_background(1)
You started moving toward the middle of the town, where you found two of your friends.
* Talk to Laura
//~add_character(0,2)
//~add_character(1,0)
Laura: "Hi! How are you?"
//~show_emotion("startled")
//~play_voiceline(1,1.5, 100)
->after_getting_up.talking_to_Laura

* Talk to Danny
//~add_character(0,2)
//~add_character(2,1)
Danny: "Did you see that car?"
//~play_voiceline(2,1, 90)
->talking_to_Danny

=talking_to_Laura
* I'm feeling really good what about you?
//~show_emotion("happy")
//~was_nice_to_Laura = true
Laura: "I'm also feeling great! Check out that car!"
You walked very fast toward the car...
->checking_the_car
*I'm not doing too well...
//~play_voiceline(3,1, 90)
Laura: "Wow that's bad! Check out that car!"
->checking_the_car
=talking_to_Danny
->checking_the_car

==checking_the_car==
You approached the mysterious car...
* [Approach Slowly]
** [Very very slowly] ->veryslowly
** [Just barely slower than walking speed] ->slowly
* [Approach Quickly]
** [Very very quickly] ->veryquickly
** [Just slightly faster than walking speed] ->quickly

=veryslowly
->death
=slowly
->death
=quickly
The car looked very weird and dangerous... 
{energylevel >0:but I was very fast!->inside_the_car|->death}
=veryquickly
The car looked very weird and dangerous... 
{energylevel >0:but I was very fast!->inside_the_car|->death}

==inside_the_car==
You reached in and opened the car from the inside,
and found a really nice green jade in it.
{was_nice_to_Laura:
    ->jade_interaction
    - else:
    ->death
}

=jade_interaction
You...
*[Hold the jade] ->hold_jade
*[Blow on the jade] -> blow_jade
*[Grab a towel and hold the jade] ->towel_jade

=hold_jade
You slowly disappear... "Mr Laura, I don't feel so good..."
//~play_voiceline(4,1, 80)
->death 

=blow_jade
Laura approaches quickly and absorbs the jade, saving you 
->survival

=towel_jade
Laura sees the jade, takes it from you, saving you 
->survival

==survival==
<> and thus you win! 
//~finished(true)
->END

==death==
<> and died.
//~finished(false)
//~play_voiceline(5,1, 100)
->END
