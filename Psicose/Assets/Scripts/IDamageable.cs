using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDamageable : MonoBehaviour
{
   public interface IDamageable
    {
        TakeDamage(int damage);
    }