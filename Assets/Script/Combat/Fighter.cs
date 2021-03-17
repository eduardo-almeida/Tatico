using UnityEngine;
using UnityEngine.SceneManagement;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat{
    public class Fighter : MonoBehaviour, IAction {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponDamage = 8f;

        float timeSingLastAttack = 0;
        Transform target;

        private void Update() {
            timeSingLastAttack += Time.deltaTime;
            if (target == null) return;
            if (!GetIsRange()) {
                GetComponent<Movimentar>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Movimentar>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour() {
            if(timeSingLastAttack > timeBetweenAttacks) {
                GetComponent<Animator>().SetTrigger("attack");
                timeSingLastAttack = 0;
                Hit();
            }
        }

        private bool GetIsRange() {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget) {
            GetComponent<ActionSchedule>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel() {
            target = null;
        }

        public void Hit() {
            Health healthComponent = target.GetComponent<Health>();
            healthComponent.TakeDamage(weaponDamage);
        }

        public void Teleporte(CombatTarget target) {
            //SceneManager.LoadScene("Combate");
        }
    }
}
