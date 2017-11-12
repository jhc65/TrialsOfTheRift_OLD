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

    // UI txt (Set in editor)
    public Text txt_playerMoveSpeed;
    public Text txt_windSpeed;
    public Text txt_iceSpeed;
    public Text txt_windCooldown;
    public Text txt_iceCooldown;

    private void Start() {
        // Player Speed
        txt_playerMoveSpeed.text = Constants.PlayerStats.C_MovementSpeed.ToString();
        slider_playerMoveSpeed.value = Constants.PlayerStats.C_MovementSpeed;

        // Wind Spell Speed
        txt_windSpeed.text = Constants.SpellStats.C_WindSpeed.ToString();
        slider_windSpeed.value = Constants.SpellStats.C_WindSpeed;

        // Ice Spell Speed
        txt_iceSpeed.text = Constants.SpellStats.C_IceSpeed.ToString();
        slider_iceSpeed.value = Constants.SpellStats.C_IceSpeed;

        // Wind Spell Cooldown
        txt_windCooldown.text = Constants.PlayerStats.C_WindCooldown.ToString();
        slider_windCooldown.value = Constants.PlayerStats.C_WindCooldown;

        // Ice Spell Cooldown
        txt_iceCooldown.text = Constants.PlayerStats.C_IceCooldown.ToString();
        slider_iceCooldown.value = Constants.PlayerStats.C_IceCooldown;
    }

    // Update is called once per frame
    private void Update() {
        /*if (gameObject.activeSelf == true) {
            Time.timeScale = 0;
        }*/

        // Player Speed
        ChangePlayerSpeed(slider_playerMoveSpeed.value);
        txt_playerMoveSpeed.text = slider_playerMoveSpeed.value.ToString();

        // Wind Spell Speed
        ChangeWindSpeed(slider_windSpeed.value);
        txt_windSpeed.text = slider_windSpeed.value.ToString();

        // Ice Spell Speed
        ChangeIceSpeed(slider_iceSpeed.value);
        txt_iceSpeed.text = slider_iceSpeed.value.ToString();

        // Wind Spell Cooldown
        ChangeWindCooldown(slider_windCooldown.value);
        txt_windCooldown.text = slider_windCooldown.value.ToString();

        // Ice Spell Cooldown
        ChangeIceCooldown(slider_iceCooldown.value);
        txt_iceCooldown.text = slider_iceCooldown.value.ToString();
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
            //Debug.Log(i_playerSpeedIn);
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
