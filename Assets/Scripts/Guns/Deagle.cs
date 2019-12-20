using Controller;
using UnityEngine;

namespace Guns {
    public class Deagle : Gun {

        public override float damage {
            get { return 13; }
        }

        public override float fireRate {
            get { return .3f; }
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

        public override int config {
            get { return 0; }
        }

        protected override void playAttackAnimation() {
            // todo anim
        }

        protected override void playReloadAnimation() {
            //todo anim
        }

        protected override void makeBullet() {
            base.makeBullet();
            var bullet = Instantiate(bulletPrefab, barrelPosition, Quaternion.Euler(0, 0, shootAngle));
            bullet.GetComponent<Bullet>().damage = damage;
            bullet.GetComponent<Bullet>().owner = owner;
        }
    }
}