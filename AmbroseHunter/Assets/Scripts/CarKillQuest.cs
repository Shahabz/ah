using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarKillQuest : MonoBehaviour {

    int carKillCount;
    public Image[] carpieces;
    public Text carCount;

    public static CarKillQuest s_instance;

    public void AddCarKill()
    {
        carKillCount++;
        UpdateKillUI();
    }

    void UpdateKillUI()
    {
        foreach(Image x in carpieces)
        {
            x.enabled = false;
        }
        carpieces[carKillCount].enabled = true;
        carCount.text = carKillCount.ToString() + "/6";
    }
	// Use this for initialization
	void Start () {
        carCount.text = "0/6";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
