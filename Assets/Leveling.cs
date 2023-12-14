using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Windows;

public class Leveling : MonoBehaviour
{
    public float level = 1f;
    public float XP = 0f;
    public float maxXpPerLvl = 100f;
    public float hp;
    public float Constitution;
    public float intelligence;
    public float Strength;
    public float defence;
    public float speed;

    void Start()
    {
        statsupgradestart(50);
    }


    void Update()
    {
        if (XP >= maxXpPerLvl)
        {
            XP -= maxXpPerLvl;
            maxXpPerLvl *= 2f;
            level++;
            statsupgrade(1.4f);

        }
    }

    void statsupgrade(float keer)
    {
        Constitution *= keer;
        intelligence *= keer;
        Strength *= keer;
        speed *= keer;
        defence *= keer;
    }
    void statsupgradestart(float keer)
    {
        for (float i = 0; i < keer; i++)
        {
            float random = Random.Range(1, 7);
            if (random == 1)
            {
                Constitution++;
            }

            if (random == 2)
            {
                Strength++;
            }

            if (random == 3)
            {
                intelligence++;
            }

            if (random == 4)
            {
                speed++;
            }

            if (random == 5)
            {
                defence++;
            }

        }
    }
}
