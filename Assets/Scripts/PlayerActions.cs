using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public static int vegCount = 0;

    public List<int> selectedVegetables;

    public void AddVegetable(int veg)
    {
        Debug.LogFormat("Veg selected ::: {0}, Player ::: {1}", veg, this.gameObject.name);

        if (vegCount < 2)
        {
            selectedVegetables[vegCount] = veg;
            vegCount++;
        }

        else
        {
            if (vegCount >= 2)
            {
                vegCount = 0;
            }
            selectedVegetables[vegCount] = veg;
            vegCount++;
        }
    }
}
