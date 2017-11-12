using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDController : MonoBehaviour {

    [SerializeField]PlayerController playc_trackedPlayer;
    [SerializeField] Image img_healthbar;
    [SerializeField] Image img_windbar;
    [SerializeField] Image img_icebar;

    private float f_lastWind;
    private float f_lastIce;

	// Use this for initialization
	void Start () {
		f_lastWind = 0;
        f_lastIce = 0;
	}
	
	// Update is called once per frame
	void Update () {
		img_windbar.fillAmount = playc_trackedPlayer.GetNextWind() / playc_trackedPlayer.f_windRecharge;
        img_icebar.fillAmount = playc_trackedPlayer.GetNextIce() / playc_trackedPlayer.f_iceRecharge;
        //img_healthbar.fillAmount = playc_trackedPlayer.GetHealth() / playc_trackedPlayer.GetMaxHealth() -or- Constants.Player.PlayerMaxHealth;
	}
}
