using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDController : MonoBehaviour {

    [SerializeField]PlayerController playc_trackedPlayer;
    [SerializeField] Image img_healthbar;
    [SerializeField] Image img_windbar;
    [SerializeField] Image img_icebar;
	
	void Update () {
		img_windbar.fillAmount = playc_trackedPlayer.GetNextWind() / playc_trackedPlayer.f_windRecharge;
        img_icebar.fillAmount = playc_trackedPlayer.GetNextIce() / playc_trackedPlayer.f_iceRecharge;
        img_healthbar.fillAmount = playc_trackedPlayer.GetCurrentHealth() / Constants.PlayerStats.C_MaxHealth;
	}
}
