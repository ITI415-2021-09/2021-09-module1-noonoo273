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
    public Text uitShots;
    public Text uitButton;
    public Vector3 hoopPos;
    public GameObject[] hoops;

    [Header("Set Dynamically")]
    public int level;
    public int levelMax;
    public int shotsTaken;
    public GameObject hoop;
    public GameModeP1 mode = GameModeP1.idle;
    public string showing = "Show Slingshot";

    // Start is called before the first frame update
    void Start()
    {
        S = this;
        level = 0;
        levelMax = hoops.Length;
        StartLevel();
    }

    void StartLevel()
    {
        if (hoop != null)
        {
            Destroy(hoop);
        }

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }

        hoop = Instantiate<GameObject>(hoops[level]);
        hoop.transform.position = hoopPos;
        shotsTaken = 0;

        ProjectileLine.S.Clear();

        Goal.goalMet = false;

        UpdateGUI();
        mode = GameModeP1.playing;
    }

    void UpdateGUI()
    {
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateGUI();

        if ((mode == GameModeP1.playing) && Goal.goalMet)
        {
            mode = GameModeP1.levelEnd;
            Invoke("NextLevel", 2f);
        }
    }

    void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            level = 0;
        }
        StartLevel();
    }


    public static void ShotFired()
    {
        S.shotsTaken++;
    }

}
