using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRock : HealthManager
{
    public SpriteRenderer spr;

    public DoorNutController parent;

    public bool isDead = false;

    public Color color;

    public override void TakeDamage (int dmg) 
    {
        //spr.color = color;
        isDead = true;
        AddHealth(100);
    }

}
