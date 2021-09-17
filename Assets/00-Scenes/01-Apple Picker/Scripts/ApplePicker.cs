using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i=0; i<numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed()
    {
        //Destroy all of the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        //Destroy basket and get index of last basket
        int basketIndex = basketList.Count - 1;
        //Get reference to that basket
        GameObject tBasketGO = basketList[basketIndex];
        //REmove basket from list and destroy GameOBject
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        //if there are no Baskets left, restart the game
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
