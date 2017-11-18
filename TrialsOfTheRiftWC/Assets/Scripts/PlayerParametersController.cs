using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerParametersController : MonoBehaviour {
    // Public Vars
    // Controllers (probably set in editor this time? No instances to pull from in this Playable)
    public GameController GC;
    public DarkMagician DM;
    public List<PlayerController> l_playerControllers = new List<PlayerController>();
    
    // UI Sliders (Set in editor)
    public Slider slider_playerMoveSpeed;
    public Slider slider_windSpeed;
    public Slider slider_iceSpeed;
    public Slider slider_windCooldown;
    public Slider slider_iceCooldown;
    public Slider slider_projSpeed;
    public Slider slider_projSize;
    public Slider slider_projLife;
    public Slider slider_windForce;
    public Slider slider_iceFreeze;
    public Slider slider_enemySpawn;
    public Slider slider_enemySpeed;
    public Slider slider_enemyHealth;
    public Slider slider_enemyDamage;
    public Slider slider_respawnTime;
	public Slider slider_wispMoveSpeed;
    public Slider slider_playerHealth;
    public Slider slider_crystalHealth;
    public Slider slider_CTFScore;

    // UI txt (Set in editor)
    public Text txt_playerMoveSpeed;
    public Text txt_windSpeed;
    public Text txt_iceSpeed;
    public Text txt_windCooldown;
    public Text txt_iceCooldown;
    public Text txt_projSpeed;
    public Text txt_projSize;
    public Text txt_projLife;
    public Text txt_windForce;
    public Text txt_iceFreeze;
    public Text txt_enemySpawn;
    public Text txt_enemySpeed;
    public Text txt_enemyHealth;
    public Text txt_enemyDamage;
    public Text txt_respawnTime;
	public Text txt_wispMoveSpeed;
    public Text txt_playerHealth;
    public Text txt_crystalHealth;
    public Text txt_CTFScore;

    //Get initial values from Constants, or from editor if they're not in Constants.
	private void Start() {
        // Player Speed
        txt_playerMoveSpeed.text = Constants.PlayerStats.C_MovementSpeed.ToString();
        slider_playerMoveSpeed.value = Constants.PlayerStats.C_MovementSpeed;

		// Player Wisp Speed
		txt_wispMoveSpeed.text = Constants.PlayerStats.C_WispMovementSpeed.ToString();
		slider_wispMoveSpeed.value = Constants.PlayerStats.C_WispMovementSpeed;

		// Wind Spell Speed
		txt_windSpeed.text = Constants.SpellStats.C_WindSpeed.ToString();
        slider_windSpeed.value = Constants.SpellStats.C_WindSpeed;

        // Ice Spell Speed
        txt_iceSpeed.text = Constants.SpellStats.C_IceSpeed.ToString();
        slider_iceSpeed.value = Constants.SpellStats.C_IceSpeed;

        // Wind Spell Cooldown
        txt_windCooldown.text = Constants.SpellStats.C_WindCooldown.ToString();
        slider_windCooldown.value = Constants.SpellStats.C_WindCooldown;

        // Ice Spell Cooldown
        txt_iceCooldown.text = Constants.SpellStats.C_IceCooldown.ToString();
        slider_iceCooldown.value = Constants.SpellStats.C_IceCooldown;

        //----------------------------
        // Projectile Speed
        txt_projSpeed.text = Constants.SpellStats.C_MagicMissileSpeed.ToString();
        slider_projSpeed.value = Constants.SpellStats.C_MagicMissileSpeed;

        // Projectile Size (Incomplete)
        txt_projSize.text = "1";
        slider_projSize.value = 1;

        // Projectile Live Time
        txt_projLife.text = Constants.SpellStats.C_SpellLiveTime.ToString();
        slider_projLife.value = Constants.SpellStats.C_SpellLiveTime;

        // Wind Force
        txt_windForce.text = Constants.SpellStats.C_WindForce.ToString();
        slider_windForce.value = Constants.SpellStats.C_WindForce;

        // Ice Freeze Duration
        txt_iceFreeze.text = Constants.SpellStats.C_IceFreezeTime.ToString();
        slider_iceFreeze.value = Constants.SpellStats.C_IceFreezeTime;

        //----------------------------

        // Enemy Spawn Rate
        txt_enemySpawn.text = Constants.EnviroStats.C_EnemySpawnTime.ToString();
        slider_enemySpawn.value = Constants.EnviroStats.C_EnemySpawnTime;
        
        // Enemy Speed
        txt_enemySpeed.text = Constants.EnviroStats.C_EnemySpeed.ToString();
        slider_enemySpeed.value = Constants.EnviroStats.C_EnemySpeed;

        // Enemy Health
        txt_enemyHealth.text = Constants.EnviroStats.C_EnemyHealth.ToString();
        slider_enemyHealth.value = Constants.EnviroStats.C_EnemyHealth;

        // Enemy Damage
        txt_enemyHealth.text = Constants.EnviroStats.C_EnemyDamage.ToString();
        slider_enemyHealth.value = Constants.EnviroStats.C_EnemyDamage;

        // Respawn Rate
        txt_respawnTime.text = Constants.PlayerStats.C_RespawnTimer.ToString();
        slider_respawnTime.value = Constants.PlayerStats.C_RespawnTimer;

        // Player Health
        txt_playerHealth.text = Constants.PlayerStats.C_MaxHealth.ToString();
        slider_playerHealth.value = Constants.PlayerStats.C_MaxHealth;

        //---------------------------
        //Crystal Health (Incomplete)
        txt_crystalHealth.text = Constants.EnviroStats.C_CrystalMaxHealth.ToString();
        slider_crystalHealth.value = Constants.EnviroStats.C_CrystalMaxHealth;

        //CTF Score (Incomplete)
        txt_CTFScore.text = Constants.EnviroStats.C_CTFMaxScore.ToString();
        slider_CTFScore.value = Constants.EnviroStats.C_CTFMaxScore;

    }

    // Update is called once per frame
    private void Update() {

    }

    // Public Helper Methods
    public void SetGameController(GameController GC_controllerIn) {
        GC = GC_controllerIn;
    }

    public void AddPlayerController(PlayerController PC_controllerIn) {
        l_playerControllers.Add(PC_controllerIn);
    }

    // Private Helper Methods
    public void ChangePlayerSpeed(float i_playerSpeedIn) {
		txt_playerMoveSpeed.text = slider_playerMoveSpeed.value.ToString();
		foreach (PlayerController playerController in l_playerControllers){
			playerController.i_moveSpeed = (int)i_playerSpeedIn;
		}
	}

	public void ChangePlayerWispSpeed(float i_playerWispSpeedIn){
		txt_wispMoveSpeed.text = slider_wispMoveSpeed.value.ToString();
		foreach (PlayerController playerController in l_playerControllers){
			playerController.i_wispSpeed = (int)i_playerWispSpeedIn;
		}
	}

	public void ChangeWindSpeed(float f_windSpeedIn) {
        txt_windSpeed.text = slider_windSpeed.value.ToString();
        foreach (PlayerController playerController in l_playerControllers) {
            playerController.f_windSpeed = f_windSpeedIn;
        }
    }

    public void ChangeIceSpeed(float f_iceSpeedIn) {
        txt_iceSpeed.text = slider_iceSpeed.value.ToString();
        foreach (PlayerController playerController in l_playerControllers) {
            playerController.f_iceSpeed = f_iceSpeedIn;
        }
    }

    public void ChangeWindCooldown(float f_windCooldownIn) {
        txt_windCooldown.text = slider_windCooldown.value.ToString();
        foreach (PlayerController playerController in l_playerControllers) {
            playerController.f_windRecharge = f_windCooldownIn;
        }
    }

    public void ChangeIceCooldown(float f_iceCooldownIn) {
        txt_iceCooldown.text = slider_iceCooldown.value.ToString();
        foreach (PlayerController playerController in l_playerControllers) {
            playerController.f_iceRecharge = f_iceCooldownIn;
        }
    }

    public void ChangeProjectileSpeed(float f_projSpeedIn) {
        txt_projSpeed.text = slider_projSpeed.value.ToString();
        foreach (PlayerController playerController in l_playerControllers) {
            playerController.f_magicMissileSpeed = f_projSpeedIn;
        }
    }

    public void ChangeProjectileSize(float f_projSizeIn) {
        txt_projSpeed.text = slider_projSpeed.value.ToString();
        foreach (PlayerController playerController in l_playerControllers) {
            playerController.f_magicMissileSpeed = f_projSizeIn;
        }
    }

    public void ChangeSpellLifetime(float f_projLifeIn) {
        txt_projLife.text = slider_projLife.value.ToString();
        Constants.SpellStats.C_SpellLiveTime = f_projLifeIn;
    }

    public void ChangeWindForce(float f_windForceIn) {
        txt_windForce.text = slider_windForce.value.ToString();
        Constants.SpellStats.C_WindForce = f_windForceIn;
    }

    public void ChangeFreezeDuration(float f_iceFreezeIn) {
        txt_iceFreeze.text = slider_iceFreeze.value.ToString();
        foreach (PlayerController playerController in l_playerControllers) {
            playerController.f_iceFreeze = f_iceFreezeIn;
        }
    }

    public void ChangeSpawnRate(float f_enemySpawnIn) {
        txt_enemySpawn.text = slider_enemySpawn.value.ToString();
        DM.f_enemySpawnTime = f_enemySpawnIn;
        DM.ResetEnemySpawnRate();
    }

    public void ChangeEnemySpeed(float f_enemySpeedIn) {
        txt_enemySpeed.text = slider_enemySpeed.value.ToString();
        Constants.EnviroStats.C_EnemySpeed = f_enemySpeedIn;
    }

    public void ChangeEnemyHealth(float f_enemyHealthIn) {
        txt_enemyHealth.text = slider_enemyHealth.value.ToString();
        Constants.EnviroStats.C_EnemyHealth = (int)f_enemyHealthIn;
    }

    public void ChangeEnemyDamage(float f_enemyDamageIn)
    {
        txt_enemyDamage.text = slider_enemyDamage.value.ToString();
        Constants.EnviroStats.C_EnemyHealth = (int)f_enemyDamageIn;
    }

    public void ChangePlayerHealth(float f_playerHealthIn) {
        txt_playerHealth.text = slider_playerHealth.value.ToString();
        Constants.PlayerStats.C_MaxHealth = f_playerHealthIn;
        foreach (PlayerController playerController in l_playerControllers) {
            playerController.SetCurrentHealth(f_playerHealthIn);
        }
    }

    public void ChangeRespawnTime(float f_respawnTimeIn) {
        txt_respawnTime.text = slider_respawnTime.value.ToString();
        Constants.PlayerStats.C_RespawnTimer = f_respawnTimeIn;
    }

    public void ChangeCrystalHealth(float f_crystalHealthIn) {
        txt_crystalHealth.text = slider_crystalHealth.value.ToString();
		Constants.EnviroStats.C_CrystalMaxHealth = (int)f_crystalHealthIn;
		if (DM.objv_blueObjective.gameObject.GetComponent<CrystalDestructionObjective>()){
			DM.objv_blueObjective.gameObject.GetComponent<CrystalDestructionObjective>().ParamReset(f_crystalHealthIn);
		}
		if (DM.objv_redObjective.gameObject.GetComponent<CrystalDestructionObjective>()) {
			DM.objv_redObjective.gameObject.GetComponent<CrystalDestructionObjective>().ParamReset(f_crystalHealthIn);
		}
    }

    public void ChangeCTFMaxScore(float f_CTFScoreIn) {
        txt_CTFScore.text = slider_CTFScore.value.ToString();
		Constants.EnviroStats.C_CTFMaxScore = (int)f_CTFScoreIn;
		if (DM.objv_blueObjective.gameObject.GetComponent<CaptureTheFlagObjective>()) {
			DM.objv_blueObjective.gameObject.GetComponent<CaptureTheFlagObjective>().ParamReset(f_CTFScoreIn);
		}
		if (DM.objv_redObjective.gameObject.GetComponent<CaptureTheFlagObjective>()){
			DM.objv_redObjective.gameObject.GetComponent<CaptureTheFlagObjective>().ParamReset(f_CTFScoreIn);
		}
	}
}
