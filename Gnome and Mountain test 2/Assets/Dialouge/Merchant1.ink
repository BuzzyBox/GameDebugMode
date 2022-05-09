

.
Hey!
Little gnome friend! 
I see you are going to climb up the mountain
I would suggest getting an some climbing equipment before attempting
Bring back a coin, I have the item you just need!


//Need to either make a true statement or a tag to trigger this
#coin 
-> haveCoin

==haveCoin==

Hey have you brought back a coin yet? 

    +[yes]
    Awesome 
    ->DONE
    +[no]
    come back later than
    ->DONE

->END