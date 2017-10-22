using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager> {
    //hidden constructor
    protected UIManager() { }

    public BattleAgent selectedAgent;

    //Text values for now
    public Text selectedAgentHealthText;
    public Text selectedAgentSpeedText;
    public Text selectedAgentHeatText;

	void Start () {
		
	}
	
	void Update () {
        UpdateStatusPane();
    }

    void UpdateStatusPane() {
        if(selectedAgent != null) {
            selectedAgentHealthText.text = "Health: " +  selectedAgent.health;
            selectedAgentHeatText.text = "Heat: " + selectedAgent.heat;
            selectedAgentSpeedText.text = "Speed: " + selectedAgent.speed;
        }
    }

    public void GetPlayerInput(int action)
    {
        BattleManager.Instance.hasPlayerGone = true;
        selectedAgent.RequestMoveAction(action);
    }
}
