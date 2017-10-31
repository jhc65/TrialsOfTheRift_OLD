using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {
    // Private Vars
    private int i_redScore;
    private int i_blueScore;

    // Public vars
    public Text text_redScoreText;
    public Text text_blueScoreText;

    // For Playstation controller support - delete once there is an official RegisterPlayers script active
    /*public GameObject go_connectMessage;
    public Text text_p1Message;
    public Text text_p2Message;
    public Text text_p3Message;
    public Text text_p4Message;
    private bool b_connected = false;
    private bool b_p1Ready = false;
    private bool b_p2Ready = false;
    private bool b_p3Ready = false;
    private bool b_p4Ready = false;*/

    // Use this for initialization
    void Start () {
        MapControllers();
	}
	
    // Update the Score
    public void Score(Constants.Color colorIn) {
        if (colorIn == Constants.Color.RED) {
            i_redScore++;
            text_redScoreText.text = i_redScore.ToString();
        }
        else if (colorIn == Constants.Color.BLUE) {
            i_blueScore++;
            text_blueScoreText.text = i_blueScore.ToString();
        }
    }

    // I wasn't sure if all four of those should be uncommented or not, so I left them commented out in the copy/paste 
    private void MapControllers()
    {
        //b_connected = true;
        //go_connectMessage.SetActive(false);

        // controller mapping defaults to XBox, so only change if PS4 controller connected
        if (Input.GetJoystickNames()[0] == "Wireless Controller") // PS4 connection message
        {
            InputManager.controlMap[InputManager.Axes.P1_Horizontal] = "P1 Horizontal PS4";
            InputManager.controlMap[InputManager.Axes.P1_Vertical] = "P1 Vertical PS4";
            InputManager.controlMap[InputManager.Axes.P1_WindSpell] = "P1 Wind Spell PS4";
            InputManager.controlMap[InputManager.Axes.P1_IceSpell] = "P1 Ice Spell PS4";
            InputManager.controlMap[InputManager.Axes.P1_Interact] = "P1 Interact PS4";
            InputManager.controlMap[InputManager.Axes.P1_Menu] = "P1 Menu PS4";
            InputManager.controlMap[InputManager.Axes.P1_Submit] = "P1 Submit PS4";
            InputManager.controlMap[InputManager.Axes.P1_Cancel] = "P1 Cancel PS4";
            Debug.Log("P1 remapped");
        }

        //if (Input.GetJoystickNames()[1] == "Wireless Controller")
        //{
        //	InputManager.controlMap[InputManager.Axes.P2_Horizontal] = "P2 Horizontal PS4";
        //	InputManager.controlMap[InputManager.Axes.P2_Vertical] = "P2 Vertical PS4";
        //	InputManager.controlMap[InputManager.Axes.P2_WindSpell] = "P2 Wind Spell PS4";
        //	InputManager.controlMap[InputManager.Axes.P2_IceSpell] = "P2 Ice Spell PS4";
        //	InputManager.controlMap[InputManager.Axes.P2_Interact] = "P2 Interact PS4";
        //	InputManager.controlMap[InputManager.Axes.P2_Menu] = "P2 Menu PS4";
        //	InputManager.controlMap[InputManager.Axes.P2_Submit] = "P2 Submit PS4";
        //	InputManager.controlMap[InputManager.Axes.P2_Cancel] = "P2 Cancel PS4";
        //	Debug.Log("P2 remapped");
        //}

        //if (Input.GetJoystickNames()[2] == "Wireless Controller")
        //{
        //	InputManager.controlMap[InputManager.Axes.P3_Horizontal] = "P3 Horizontal PS4";
        //	InputManager.controlMap[InputManager.Axes.P3_Vertical] = "P3 Vertical PS4";
        //	InputManager.controlMap[InputManager.Axes.P3_WindSpell] = "P3 Wind Spell PS4";
        //	InputManager.controlMap[InputManager.Axes.P3_IceSpell] = "P3 Ice Spell PS4";
        //	InputManager.controlMap[InputManager.Axes.P3_Interact] = "P3 Interact PS4";
        //	InputManager.controlMap[InputManager.Axes.P3_Menu] = "P3 Menu PS4";
        //	InputManager.controlMap[InputManager.Axes.P3_Submit] = "P3 Submit PS4";
        //	InputManager.controlMap[InputManager.Axes.P3_Cancel] = "P3 Cancel PS4";
        //	Debug.Log("P3 remapped");
        //}

        //if (Input.GetJoystickNames()[3] == "Wireless Controller")
        //{
        //	InputManager.controlMap[InputManager.Axes.P4_Horizontal] = "P4 Horizontal PS4";
        //	InputManager.controlMap[InputManager.Axes.P4_Vertical] = "P4 Vertical PS4";
        //	InputManager.controlMap[InputManager.Axes.P4_WindSpell] = "P4 Wind Spell PS4";
        //	InputManager.controlMap[InputManager.Axes.P4_IceSpell] = "P4 Ice Spell PS4";
        //	InputManager.controlMap[InputManager.Axes.P4_Interact] = "P4 Interact PS4";
        //	InputManager.controlMap[InputManager.Axes.P4_Menu] = "P4 Menu PS4";
        //	InputManager.controlMap[InputManager.Axes.P4_Submit] = "P4 Submit PS4";
        //	InputManager.controlMap[InputManager.Axes.P4_Cancel] = "P4 Cancel PS4";
        //	Debug.Log("P4 remapped");
        //}
    }

    public void SetConnectMessage(GameObject go_connectMessageIn) {
        //go_connectMessage = go_connectMessageIn;
    }
}
