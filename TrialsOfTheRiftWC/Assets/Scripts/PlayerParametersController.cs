using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerParametersController : MonoBehaviour
{
    // Public Vars
    // Controllers (probably set in editor this time? No instances to pull from in this Playable)
    public GameController GC;
    public List<PlayerController> l_playerControllers = new List<PlayerController>();
    // UI Sliders (Set in editor)
    public Slider slider_playerMoveSpeed;
    //public Slider slider_spellSpeed;
    public Slider slider_windSpeed;
    public Slider slider_iceSpeed;
    public Slider slider_windCooldown;
    public Slider slider_iceCooldown;

    // UI Text (Set in editor)
    public Text text_playerMoveSpeed;
    public Text text_windSpeed;
    public Text text_iceSpeed;
    public Text text_windCooldown;
    public Text text_iceCooldown;

    private void Start() {
        
    }

    // Update is called once per frame
    private void Update() {
        /*if (gameObject.activeSelf == true) {
            Time.timeScale = 0;
        }*/

        // Player Speed
        ChangePlayerSpeed(slider_playerMoveSpeed.value);
        text_playerMoveSpeed.text = slider_playerMoveSpeed.value.ToString();

        // Wind Spell Speed
        ChangeWindSpeed(slider_windSpeed.value);
        text_windSpeed.text = slider_windSpeed.value.ToString();

        // Ice Spell Speed
        ChangeIceSpeed(slider_iceSpeed.value);
        text_iceSpeed.text = slider_iceSpeed.value.ToString();

        // Wind Spell Cooldown
        ChangeWindCooldown(slider_windCooldown.value);
        text_windCooldown.text = slider_windCooldown.value.ToString();

        // Ice Spell Cooldown
        ChangeIceCooldown(slider_iceCooldown.value);
        text_iceCooldown.text = slider_iceCooldown.value.ToString();
    }

    // Public Helper Methods
    public void SetGameController(GameController GC_controllerIn) {
        GC = GC_controllerIn;
    }

    public void AddPlayerController(PlayerController PC_controllerIn) {
        l_playerControllers.Add(PC_controllerIn);
    }

    // Private Helper Methods
    private void ChangePlayerSpeed(float i_playerSpeedIn) {
        foreach (PlayerController playerController in l_playerControllers) {
            Debug.Log(i_playerSpeedIn);
            playerController.i_moveSpeed = (int)i_playerSpeedIn;
        }
    }

    private void ChangeWindSpeed(float f_windSpeedIn) {
        foreach (PlayerController playerController in l_playerControllers) {
            playerController.f_windSpeed = f_windSpeedIn;
        }
    }

    private void ChangeIceSpeed(float f_iceSpeedIn) {
        foreach (PlayerController playerController in l_playerControllers) {
            playerController.f_iceSpeed = f_iceSpeedIn;
        }
    }

    private void ChangeWindCooldown(float f_windCooldownIn) {
        foreach (PlayerController playerController in l_playerControllers) {
            playerController.f_windRecharge = f_windCooldownIn;
        }
    }

    private void ChangeIceCooldown(float f_windCooldownIn) {
        foreach (PlayerController playerController in l_playerControllers) {
            playerController.f_iceRecharge = f_windCooldownIn;
        }
    }
}
