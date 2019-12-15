using System;
using Controller;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Guns {
    public class Deagle : Gun {
        public override Sprite renderedSprite {
            get { return GameController.instance.gunSprites[0]; }
        }

        public override float damage {
            get { return 13; }
        }

        public override float fireRate {
            get { return .5f; }
        }

        public override int magSize {
            get { return 7; }
        }

        public override float reloadTime {
            get { return 1;  }
        }

        public override float recoil {
            get { return 15; }
        }

        public override float inaccuracy {
            get { return 5; }
        }

        protected override void playAnimation() {
            Debug.Log("Shoot anim here");
        }

        protected override void makeBullet() {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, shootAngle));
            bullet.GetComponent<Bullet>().damage = damage;
            bullet.GetComponent<Bullet>().owner = owner;
        }
        
        protected override void reload() {
            base.reload();
            Debug.Log("Reload anim here");
        }
    }
}