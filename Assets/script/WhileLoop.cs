using System.Collections;
using UnityEngine;

public class WhileLoop : MonoBehaviour
{
    int KillOrcs = 5;

    // Start is called before the first frame update
    void Start()
    {
        while (KillOrcs > 0)
        {
            Debug.Log("i killed an orc");
            KillOrcs--;
        }
    }

}
