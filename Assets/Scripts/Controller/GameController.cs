using System;
using System.Collections;
using Guns;
using Melees;
using Units;
using Units.Enemies;
using UnityEngine;
using UnityEngine.Assertions;

namespace Controller {
    public class GameController : MonoBehaviour {
        public GameController() {
            Assert.IsNull(instance);
            instance = this;
            level = 1;
            hardNess = 1;
        }

        public static GameController instance { get; private set; }

        public Sprite[] gunSprites;
        public Sprite[] meleeSprites;
        [SerializeField]
        private Player _player;

        public int level { get; private set; }
        public int hardNess { get; private set; }
        
        public Player player {
            get { return _player; }
        }

        public Enemy[] enemyList {
            get { return GetComponentsInChildren<Enemy>(); }
        }

        private IEnumerator Start() {
            yield return new WaitForSeconds(5);
            Debug.Log("Weapon set");
            player.setWeapon<Shoty>();
        }
    }
}