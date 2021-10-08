using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameModeP1
{
    idle, playing, levelEnd
}

public class Prototype1 : MonoBehaviour
{

    static private Prototype1 S;

    [Header("Set in Inspector")]
    public Text uitLevel;
    public Text uitLives;
    public Text uitButton;
    //public Vector3 hoopPos;
    public GameObject[] hoops;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public List<GameObject> ballList;

    [Header("Set Dynamically")]
    public int level;
    public int levelMax;
    public int Lives = 3;
    public GameObject hoop;
    public GameModeP1 mode = GameModeP1.idle;
    public string showing = "Show Slingshot";

    // Start is called before the first frame update
    void Start()
    {
        S = this;
        level = 0;
        levelMax = hoops.Length;
        //StartLevel();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    //void StartLevel()
    //{
    //    // Get rid of old hoop if one exists
    //    if (hoop != null)
    //    {
    //        DestroyImmediate(hoop, true);
    //    }

    //    //Destroy old projectiles if they exist
    //    GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
    //    foreach (GameObject pTemp in gos)
    //    {
    //        Destroy(pTemp);
    //    }

    //    //Instantiate new Hoop
    //    hoop = Instantiate<GameObject>(hoops[level]);
    //    //hoop.transform.position = hoopPos;
    //    Lives = 3;

    //    SwitchView("Show Both");
    //    ProjectileLine.S.Clear();

    //    Goal.goalMet = false;

    //    UpdateGUI();
    //    mode = GameModeP1.playing;
    //}

    void UpdateGUI()
    {
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitLives.text = "Shots Taken: " + S.Lives;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateGUI();

        if ((mode == GameModeP1.playing) && Goal.goalMet)
        {
            mode = GameModeP1.levelEnd;
            Invoke("NextLevel", 2f);
            winTextObject.SetActive(true);
        }
        
        if (S.Lives < 1)
        {
            loseTextObject.SetActive(true);
        }
    }

    void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            level = 0;
        }
        //StartLevel();
    }

    public void SwitchView(string eView = "")
    {
        if (eView == "")
        {
            eView = uitButton.text;
        }

        showing = eView;

    }


    public static void ShotFired()
    {
        S.Lives--;
    }

}
