/*
 *  Author: ariel oliveira [o.arielg@gmail.com]
 */

using UnityEngine;

public class HealthBarHUDTester : MonoBehaviour
{
 

    
    public void Hurt(float dmg)
    {
        PlayerStats.Instance.TakeDamage(dmg);
    }
}
