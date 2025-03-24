using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Main.Start ±»µ÷ÓÃ");
        UIManager.Instance.ShowPanel<BeginPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
