using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class PointsManagerScript : MonoBehaviour
{
    // Add a check to see if even all of the slots are taken like top bottom and shoes

    public static PointsManagerScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public UnityEvent OnSlotted;

    public List<slotscript> slotscripts;

    public Dictionary<TypesScript.Clothingstyle, int> stylematches = new Dictionary<TypesScript.Clothingstyle, int>();

    public Dictionary<TypesScript.Clothingcolour, int> colourmatches = new Dictionary<TypesScript.Clothingcolour, int>();

    public int finalscore = 0;

    public void Calculate()
    {
        Debug.Log("work");
        AddToBasket();
        CalculateScore();
    }

    // We add all the clothes from slots into the style and colour lists and count how many
    public void AddToBasket()
    {
        foreach (slotscript item in slotscripts)
        {
            if (item.slotteditem == null)
            {
                return;
            }
            ClothesScript clothesscript = item.slotteditem.GetComponent<ClothesScript>();


            if (stylematches.ContainsKey(clothesscript.clothingstyle))
            {
                stylematches[clothesscript.clothingstyle] += 1;
            }
            else
            {
                stylematches.Add(clothesscript.clothingstyle, 1);
            }

            if (colourmatches.ContainsKey(clothesscript.clothingcolour))
            {
                colourmatches[clothesscript.clothingcolour] += 1;
            }
            else
            {
                colourmatches.Add(clothesscript.clothingcolour, 1);
            }
        }

    }

    public int CalculatePoints(int matches)
    {
        int pointsgiven = Mathf.RoundToInt(Mathf.Pow(5, matches));
        return pointsgiven;
    }

    public void CalculateScore()
    {


        finalscore = 0; // Might change base score depending on other stuff like game stuff

        foreach (var style in stylematches)
        {
            finalscore += style.Value * style.Value * 10;
        }

        foreach (var colour in colourmatches)
        {
            finalscore += colour.Value * colour.Value * 10;
        }

        Debug.Log("Final score is: " + finalscore);
    }

}
