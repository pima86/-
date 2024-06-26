using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Pet_ControlTower : MonoBehaviour
{
    public Pet_Interface pet;

    [Header("허기")] public int food;
    public int Food { get => food;
        set
        {
            if (value > GameManager.inst.Max_Food) food = (int)GameManager.inst.Max_Food;
            else if (value < 0) food = 0;
            else food = value;
        }
    }

    [Header("위생")] public int wash;
    public int Wash { get => wash; 
        set
        {
            if (value > GameManager.inst.Max_Wash) wash = (int)GameManager.inst.Max_Wash;
            else if (value < 0) wash = 0;
            else wash = value;
        }
    }

    [Header("행복")] public int happy;
    public int Happy { get => happy; 
        set
        {
            if (value > GameManager.inst.Max_Happy) happy = (int)GameManager.inst.Max_Happy;
            else if (value < 0) happy = 0;
            else happy = value;
        }
    }
}
