using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PowerupEffects code by Ryan Horton
public abstract class PowerupEffect : ScriptableObject
{
   public abstract void Apply(GameObject target);
}
