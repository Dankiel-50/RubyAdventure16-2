using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SpeedBuffs code by Ryan Horton

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class SpeedBuff : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject target)
{
    target.GetComponent<RubyController>().speed += amount;
    target.GetComponent<SpriteRenderer>().color = Color.red;
    }
}

