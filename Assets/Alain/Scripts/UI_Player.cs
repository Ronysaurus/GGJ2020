using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Player : MonoBehaviour
{
    Scr_PlayerStats Player_Stats;
    int UI_HP;
    float UI_Gold;
    int UI_Nexus;
    int UI_HP_Turret;
    public Text Player_Text_HP;
    public Text Player_Text_Gold;
    public Text Player_Text_Nexus;
    public Text Turret_Text_HP;

    // Start is called before the first frame update
    void Start()
    {
        Player_Stats = FindObjectOfType<Scr_PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        UI_HP = (int)Player_Stats.GetHP();
        Player_Text_HP.text = "HP: "+UI_HP.ToString();
        UI_Gold = (int)Player_Stats.getGold();
        Player_Text_Gold.text = "Gold: " + UI_Gold.ToString();
        UI_Nexus = FindObjectOfType<GameManager>().hp;
        Player_Text_Nexus.text = "Nexus: " + UI_Nexus.ToString();
       // UI_HP_Turret = (int)FindObjectOfType<Scr_turret>().hp;
       // Turret_Text_HP.text = ""+UI_HP_Turret.ToString();
    }
}
