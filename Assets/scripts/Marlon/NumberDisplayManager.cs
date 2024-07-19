using UnityEngine;
using UnityEngine.UI;

public class NumberDisplayManager : MonoBehaviour
{
    // both of these hold arrays of the diffrent sprites and where they should be shown
    public Sprite[] numberSprites; 
    public Image[] numberImages;   

    // Sets the numbers to display
    public void SetNumber(int number)
    {
        string numberString = number.ToString();

        for (int i = 0; i < numberString.Length; i++)
        {
            int digit = int.Parse(numberString[i].ToString());
            if (i < numberImages.Length)
            {
                numberImages[i].sprite = numberSprites[digit];
            }
        }
    }
}
