using UnityEngine;
using UnityEngine.UI;

public class Palette : MonoBehaviour
{
    public int[] amount;
    public int num;

    public GameObject[] blocks;

    public GameObject selectedBlock;

    public Text[] amountTXT;

    void Start()
    {
        for (int i = 0; i < amount.Length; i++)
            amountTXT[i].text = amount[i].ToString();
    }
    public void SelectColor(int num_)
    {
        num = num_;
        selectedBlock = blocks[num];
    }
}
