using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Destructiable
{
    public int score = 3000;
    public override void Dead()
    {
        base.Dead();
        GameManager.Instance.OnPigDead();
        ScoreManager.Instance.ShowScore(transform.position,score);
    
    }
}
