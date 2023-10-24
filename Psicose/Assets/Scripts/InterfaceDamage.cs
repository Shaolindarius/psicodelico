using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceDamage : MonoBehaviour
{
    public interface IDamageable
    {
        void TakeDamage(int damage);
    }
}