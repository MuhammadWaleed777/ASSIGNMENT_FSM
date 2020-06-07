using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HealthPoints
    {
        get
        {
            return healthPoints;
        }
         set
        {
            healthPoints = value;

            //what if we reach zero
            if (healthPoints <= 0)
            {

                Destroy(gameObject);

            }
    }
}
[SerializeField]
public float healthPoints = 100f;
}
