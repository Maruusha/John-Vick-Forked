namespace Units.Enemies.Bosses {
    public class Virgo : Archer {
        private float _minDistance;
        protected override void Start() {
            base.Start();
            maxHp = 350;
            hp = 350;
            moveSpeed = .75f;
        }
    }
}