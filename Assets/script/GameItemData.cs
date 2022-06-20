using UnityEngine;

public class GameItemData
{
    public Sprite Sprite;
    public int Amount;

    public GameItemData(Sprite sprite)
    {
        Sprite = sprite;
        Amount = 1;
    }

    public void IncreaseAmount()
    {
        Amount++;
    }

    public bool DecreaseAmount()
    {
        Amount--;
        if (Amount <= 0)
        {
            return false;
        }

        return true;
    }
}