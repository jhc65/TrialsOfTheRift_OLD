using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants {
    // Player Constants
    public static class PlayerStats {
        public static int MovementSpeed = 20;
        public static int WispMovementSpeed = 10;
        public static float MaxHealth = 300.0f;
        public static float MagicMissileCooldown = 0.5f;
        public static float IceCooldown = 3.0f;
        public static float WindCooldown = 5.0f;
        public static float RespawnTime = 5.0f;
    }

    // Spell Constants
    public static class SpellStats {
        public static float MagicMissileSpeed = 20.0f;
        public static float IceSpeed = 25.0f;
        public static float WindSpeed = 25.0f;
    }

    // Team Constants
	public enum Color { RED, BLUE }; 
	public enum Side { LEFT, RIGHT };
	public static GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
	
	// World Constants
	public static Transform RiftTransform = GameObject.FindGameObjectsWithTag("Rift")[0].transform;
}