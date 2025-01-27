using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class StarScript : MonoBehaviour
{
    public float totalStars;
    public int topScore;
    public int currentScore;


    string Stars()
    {
        // 3/(TopScore /score)

        totalStars = 5/(topScore / currentScore);



        return String.Concat(Enumerable.Repeat("*", (int)totalStars));
    
    }
    

    
}
