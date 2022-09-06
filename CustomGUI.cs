using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CustomGUI : MonoBehaviour
{
    public GUISkin skin;
    Slot slot;
    bool togglePays;
    
    public TextMeshProUGUI goldCredits, totalBet, totalLine, spinText;
    float timer;
    float maxtime = 5f;
    public GameObject title;
    public Canvas canvas;
    
   
  



    void Start()
    {
        canvas.enabled = false;
        title.SetActive(true);
        slot = GetComponent<Slot>();
        PlayerPrefs.SetInt(slot.name + "_credits", 1000);
        goldCredits.text = slot.refs.credits.totalCreditsReadout().ToString();
        totalBet.text = slot.refs.credits.betPerLine.ToString();
        totalLine.text = slot.refs.credits.linesPlayed.ToString();
        spinText.text = "Spin";
    

    }

    // Update is called once per frame
    void Update()
    {
        goldCredits.text = slot.refs.credits.totalCreditsReadout().ToString();
        timer += Time.deltaTime;
        if (timer > maxtime)
        {
            canvas.enabled = true;
            title.SetActive(false);
        }
    }
    public void HomeButton()
    {
        PlayerPrefs.SetInt("gold", slot.refs.credits.credits);
    }

    void OnGUI()
    {
        if (togglePays)
        {
            Rect windowRect = new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.8f, Screen.height * 0.8f);
            windowRect = GUI.Window(0, windowRect, ShowPays, "Pays");

        }

        spinText.text = "spin";
        switch (slot.state)
        {
              case SlotState.playingwins:
                if (slot.refs.wins.currentWin == null) return;
                GUI.Label(new Rect(0, Screen.height - 125, Screen.width, 50), slot.refs.wins.currentWin.readout.ToString());
                GUI.Label(new Rect(0, Screen.height - 75, Screen.width, 50), "Total Won: " + slot.refs.credits.lastWin.ToString());
                
                break;
            case SlotState.ready:
               ;
                break;
            case SlotState.snapping:
                break;
            case SlotState.spinning:
                spinText.text = "Stop";
                break;
        }

    }


    void ShowPays(int windowID)
    {
        
            GUI.skin.label.alignment = TextAnchor.MiddleLeft;
            GUI.contentColor = Color.black;
            for (int setIndex = 0; setIndex < slot.symbolSets.Count; setIndex++)
            {
                GUI.Label(new Rect(25, 60 + (30 * setIndex), 200, 50), slot.symbolSetNames[setIndex]);
                for (int payIndex = 0; payIndex < slot.setPays[setIndex].pays.Count; payIndex++)
                {
                    if (setIndex == 0)
                    {
                        GUI.Label(new Rect(250 + (50 * payIndex), 30, 50, 50), (payIndex + 1).ToString());
                    }
                    string pay = slot.setPays[setIndex].pays[payIndex].ToString();
                    if (pay == "0") pay = "-";
                    GUI.Label(new Rect(250 + (50 * payIndex), 60 + (30 * setIndex), 50, 50), pay);
                }
            }
        }

    }

