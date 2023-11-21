using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idamageable : MonoBehaviour
{
    public interface IDamageable
    {
        void TakeDamage(int damageAmount);
    }

}
