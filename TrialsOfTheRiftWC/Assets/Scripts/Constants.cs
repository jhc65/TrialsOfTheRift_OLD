using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants {
    // Player Constants
    public static class PlayerStats {
        public static int C_MovementSpeed = 13;
        public static int C_WispMovementSpeed = 2;
        public static float C_RespawnTimer = 5.0f;
        public static float C_MaxHealth = 300.0f;
    }

    // Spell Constants
    public static class SpellStats {
		public static float C_SpellLiveTime = 2.0f;
		public static float C_MagicMissileSpeed = 20.0f;
        public static float C_IceSpeed = 25.0f;
        public static float C_WindSpeed = 25.0f;
        public static float C_MagicMissileDamage = 25.0f;       // Officially, this is -25 HP
        public static float C_IceDamage = 75.0f;                // Officially, this is -75 HP
        public static float C_WindDamage = 50.0f;               // Officially, this is -50 HP
		public static float C_MagicMissileCooldown = 0.25f;
		public static float C_IceCooldown = 5.0f;
		public static float C_WindCooldown = 2.0f;
        public static float C_WindForce = 6000f;                // [Param Fix]
        public static float C_IceFreezeTime = 2f;               // [Param Fix]

		// Spell Buffs when crossing Rift
		public static float C_IceSpeedMultiplier = 1.5f;
        public static float C_WindSpeedMultiplier = 1.5f;
        public static float C_IceDamageMultiplier = 1.25f;
        public static float C_WindDamageMultiplier = 1.25f;
        public static float C_SpellScaleMultiplier = 1.15f;
    }
       
    // [Param Fix] - This entire class and its values are parameter fixes.
    // The values were pulled from the files they came from, so no real worries there.
    public static class EnviroStats {
        public static float C_EnemySpawnTime = 10f;             
        public static float C_EnemySpeed = 3.5f;
        public static int C_EnemyHealth = 75;
        public static float C_EnemyDamage = 25.0f;
        public static int C_CrystalMaxHealth = 500;
        public static int C_CTFMaxScore = 3;
    }

    // Team Constants
	public enum Color { RED, BLUE };
	public enum Side { LEFT = -1, RIGHT = 1 };
	public static Vector3 C_RedObjectiveSpawn = new Vector3(20f, 0.5f, 0f);	//i.e. the Blue Flag Red Players are trying to retrieve
	public static Vector3 C_BlueObjectiveSpawn = new Vector3(-20f, 0.5f, 0f);
    public static Vector3 C_RedObjectiveGoal = new Vector3(-3f, .01f, 0f);	//i.e. Red's base the Blue's Flag must be returned to
	public static Vector3 C_BlueObjectiveGoal = new Vector3(3f, .01f, 0f);
	public static GameObject[] C_Players = GameObject.FindGameObjectsWithTag("Player");
}
