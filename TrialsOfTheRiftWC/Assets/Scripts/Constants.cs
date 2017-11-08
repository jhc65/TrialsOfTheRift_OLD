using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants {
    // Player Constants
    public static class PlayerStats {
        public static int C_MovementSpeed = 20;
        public static int C_WispMovementSpeed = 10;
        public static float C_MaxHealth = 300.0f;
        public static float C_MagicMissileCooldown = 0.5f;
        public static float C_IceCooldown = 3.0f;
        public static float C_WindCooldown = 5.0f;
        public static float C_RespawnTime = 5.0f;
    }

    // Spell Constants
    public static class SpellStats {
        public static float C_MagicMissileSpeed = 20.0f;
        public static float C_IceSpeed = 25.0f;
        public static float C_WindSpeed = 25.0f;
    }

    // Team Constants
	public enum Color { RED, BLUE };
	public enum Side { LEFT = -1, RIGHT = 1 };
	public static Vector3 C_RedObjectiveSpawn = new Vector3(13.2f, 0.5f, 2f);	//i.e. the Blue Flag Red Players are trying to retrieve
	public static Vector3 C_BlueObjectiveSpawn = new Vector3(-13.2f, 0.5f, 2f);
	public static Vector3 C_RedObjectiveGoal = new Vector3(-5f, .01f, 2f);	//i.e. Red's base the Blue's Flag must be returned to
	public static Vector3 C_BlueObjectiveGoal = new Vector3(5f, .01f, 2f);

}
