using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Controller;
using Guns;
using Melees;
using Skills;
using UnityEngine;
using UnityEngine.Assertions;
using Random = UnityEngine.Random;

namespace Units {
	[RequireComponent(typeof(Movable))]
	public abstract class Unit : MonoBehaviour {
		protected WeaponController weaponController { get; private set; }
        public List<Skill> skills = new List<Skill>();
        [SerializeField] private float _hp = 100;

        public float hp {
	        get { return _hp; }
	        set { _hp = value; }
        }

        public float armor { get; set; }
		public abstract UnitType type { get; }
		public float moveSpeed {
			get { return movable.speed; }
			protected set {
				movable.speed = value;
			}
		}

		public abstract float evasion { get; set; }

		private float _tempMoveSpeed;
		protected Movable movable;
		public float maxHp;

		public Weapon weapon {
			get { return weaponController.weapon; }
		}

		public Weapon setWeapon<T>() where T : Weapon {
			var weapon = weaponController.setWeapon<T>();
			var gun = weapon as Gun;
			if (gun != null) {
				gun.magNum = 2;
				gun.mag = gun.magSize;
			}
			Debug.Log("unit.setWeapon: " + weapon.type);
			return weapon;
		}

		public void setWeapon(WeaponName weaponName) {
			switch (weaponName) {
				case WeaponName.Deagle:
					setWeapon<Deagle>();
					break;
				case WeaponName.AssaultRifle:
					setWeapon<AssaultRifle>();
					break;
				case WeaponName.Shoty:
					setWeapon<Shoty>();
					break;
				case WeaponName.Sniper:
					setWeapon<Sniper>();
					break;
				case WeaponName.Hand:
					setWeapon<Hand>();
					break;
				case WeaponName.Knife:
					setWeapon<Knife>();
					break;
				case WeaponName.Pencil:
					setWeapon<Pencil>();
					break;
				default:
					throw new ArgumentOutOfRangeException("weaponName", weaponName, null);
			}
		}

		public void randomWeapon(WeaponType weaponType) {
			if (weaponType == WeaponType.Gun) {
				var index = Random.Range(0, 99);
				if (index <= 5)
					setWeapon<Sniper>();
				else if (index <= 20)
					setWeapon<Shoty>();
				else if (index == 35)
					setWeapon<AssaultRifle>();
				else
					setWeapon<Deagle>();
			}
			else {
				var index = Random.Range(0, 4);
				switch (index) {
					case 1:
						setWeapon<Knife>();
						break;
					default:
						setWeapon<Hand>();
						break;
				}
			}
		}


		public void damage(float v) {
			hp -= v;
//			Debug.Log(gameObject.name + " hp: " + hp);
			if (hp <= 0) {
				//todo: play dead animation
				hp = 0;
				onDead();
			}
		}

		public void heal(float v) {
			hp += v;
		}

		protected virtual void onDead(float after = 0) {
			Destroy(gameObject, after);
		}

		protected virtual void Awake() {
			movable = GetComponent<Movable>();
			weaponController = GetComponentInChildren<WeaponController>();
			Assert.IsNotNull(movable);
			Assert.IsNotNull(weaponController);
			weaponController.unit = this;
			foreach (var skill in skills) {
				skill.unit = this;
			}
		}

		public void increaseMoveSpeed(float v, float duration) {
			_tempMoveSpeed = moveSpeed;
			moveSpeed = v;
			StartCoroutine(resetMoveSpeed(duration));
		}

		private IEnumerator resetMoveSpeed(float after) {
			yield return new WaitForSeconds(after);
			moveSpeed = _tempMoveSpeed;
		}

		public void useSkill(int index) {
			skills[index].use();
		}
		public void useSkill<T>() where T : Skill {
			skills.First(s => s is T).use();
		}
		public void useAllSkills() {
			skills.ForEach(s => s.use());
		}
	}
}
