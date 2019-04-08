using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public int vegCount = 0;

    public List<int> selectedVegetables;
    public List<int> choppedVegetables;
    public bool isChopping = false;

    [SerializeField]
    private List<GameObject> dummyVeg;
    [SerializeField]
    private List<Material> vegMaterials;
    [SerializeField]
    private GameObject ChoppingVeg;
    private bool vegAvailable = false;
    private int overrideVeg = 0;

    private void Awake()
    {
        foreach (var item in dummyVeg)
        {
            item.SetActive(false);
        }
        ChoppingVeg.SetActive(false);
    }
    public void AddVegetable(int veg, GameObject vegRef)
    {
        Debug.Log("Veg selected ::: " + veg + "_____" + "Player ::: " + this.gameObject.name);

        if (vegCount < 2)
        {
            vegAvailable = true;

            //selectedVegetables[vegCount] = veg;
            selectedVegetables.Add(veg);
            dummyVeg[vegCount].gameObject.GetComponent<Renderer>().material = vegRef.GetComponent<Renderer>().material;
            vegMaterials[vegCount] = dummyVeg[vegCount].gameObject.GetComponent<Renderer>().material;
            dummyVeg[vegCount].SetActive(true);

            vegCount++;
        }

        else
        {
            if (overrideVeg >= 2)
            {
                overrideVeg = 0;
            }
            //selectedVegetables[vegCount] = veg;
            selectedVegetables[overrideVeg] = veg;
            dummyVeg[overrideVeg].gameObject.GetComponent<Renderer>().material = vegRef.GetComponent<Renderer>().material;
            vegMaterials[overrideVeg] = dummyVeg[overrideVeg].gameObject.GetComponent<Renderer>().material;
            dummyVeg[overrideVeg].SetActive(true);

            overrideVeg++;
        }
    }

    public void CallForChop()
    {
        if (selectedVegetables.Count == 0 || isChopping)
        {
            return;
        }

        StartCoroutine(StartChopping());
    }

    IEnumerator StartChopping()
    {
        isChopping = true;
        int i = 0;

        foreach (var veg in selectedVegetables)
        {
            ChoppingVeg.GetComponent<Renderer>().material = vegMaterials[i];
            dummyVeg[i].SetActive(false);
            ChoppingVeg.SetActive(true);

            yield return new WaitForSeconds(3f);

            i++;
        }

        //vegCount = 0;
        //selectedVegetables.Clear();
        vegAvailable = false;
        isChopping = false;
        ChoppingVeg.SetActive(false);
    }
}
