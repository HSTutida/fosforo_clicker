using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float tree; //static so the variable is accessed in another class
                          //this is the currency of the game
                            
    public static float multiplier; //the buy buttons increases the speed of the click by multiplier times
    // Start is called before the first frame update

    public static float cloud; //cloud quantity

    public static float cow;

    public static float poop;

    public static float skull;

    public static float plantTime; //clock for the plant, 

    public static float poopTime;

    public static float skullTime;

    public static float cloudTime;



    void Start()
    {
        multiplier = 1; //the multiplier starts at 1
        tree = 0; // the  currency starts at zero
        cloud = 1000;
        cow = 0;
        poop = 0;
        skull = 0;
        plantTime = 0;
        poopTime = 0;
        skullTime = 0;
        cloudTime = 0;
    }

}
