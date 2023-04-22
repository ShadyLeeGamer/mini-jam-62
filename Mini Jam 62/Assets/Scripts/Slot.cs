using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject currentBlock;

    SpriteRenderer spriteRenderer;

    Palette palette;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        palette = FindObjectOfType<Palette>();
    }

    void OnMouseDown()
    {
        if (palette.selectedBlock)
        {
            if (currentBlock)
            {
                int pastSelect = currentBlock.GetComponent<Order>().order;

                if (palette.num == pastSelect)
                {
                    Destroy(currentBlock);

                    spriteRenderer.enabled = true;

                    palette.amount[palette.num]++;
                    palette.amountTXT[palette.num].text = palette.amount[palette.num].ToString();
                    return;
                }
                else if (palette.amount[palette.num] > 0)
                {
                    Destroy(currentBlock);

                    currentBlock = Instantiate(palette.selectedBlock, transform.position, Quaternion.identity);

                    palette.amount[pastSelect]++;
                    palette.amountTXT[pastSelect].text = palette.amount[pastSelect].ToString();
                    palette.amount[palette.num]--;
                    palette.amountTXT[palette.num].text = palette.amount[palette.num].ToString();
                }
            }
            else if (palette.amount[palette.num] > 0)
            {
                spriteRenderer.enabled = false;

                currentBlock = Instantiate(palette.selectedBlock, transform.position, Quaternion.identity);

                palette.amount[palette.num]--;
                palette.amountTXT[palette.num].text = palette.amount[palette.num].ToString();
            }

        }
    }
}
