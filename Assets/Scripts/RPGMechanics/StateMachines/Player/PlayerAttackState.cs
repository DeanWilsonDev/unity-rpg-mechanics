using RPGMechanics.Weapons;

using UnityEngine;

namespace RPGMechanics.StateMachines.Player
{
    public class PlayerAttackState : PlayerBaseState
    {
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        public PlayerStateMachine PlayerStateMachine { get; set; }

        private LayerMask hitLayerMask = LayerMask.GetMask("Enemy");
        private RaycastHit hit;


        public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
            PlayerStateMachine = stateMachine;
        }

        public override void Enter()
        {
            // Debug.Log("Attack State Entered");
            PlayerStateMachine.PlayerCharacter.Animator.SetBool(IsAttacking, true);
        }

        public override void Tick(float deltaTime)
        {
            // Add logic for attacking
            //Debug.Log("Attack State Tick");
            Attack();

            // TODO: A next function would be so much better than this
            PlayerStateMachine.SwitchState(new PlayerFreeLookState(PlayerStateMachine));
        }

        public override void Exit()
        {
            // Debug.Log("Attack State Exit");
            PlayerStateMachine.PlayerCharacter.InputReader.IsAttacking = false;
            PlayerStateMachine.PlayerCharacter.Animator.SetBool(IsAttacking, false);
        }

        public void Attack()
        {
            Transform attackOrigin = PlayerStateMachine.transform;
            Vector3 direction = attackOrigin.forward;
            Weapon currentWeapon = stateMachine.PlayerCharacter.CurrentWeapon;

            var success = Physics.SphereCast(attackOrigin.position, currentWeapon.Radius, direction, out hit,
                currentWeapon.Range,
                hitLayerMask);

            Debug.DrawRay(attackOrigin.position, direction * currentWeapon.Range, Color.red, 1.0f);

            if (success)
            {
                Debug.Log($"Hit: {hit.collider.name}");
                var enemy = hit.collider.GetComponent<Characters.Enemies.Enemy>();
                if (enemy)
                {
                    enemy.TakeDamage(currentWeapon.Damage);
                }
            }
        }

        // TODO: This function needs to be implemented but it probably wont work here.
        // TODO: Debug class?
        private void OnDrawGizmos()
        {
            if (!PlayerStateMachine) { return; }
            Transform attackOrigin = PlayerStateMachine.transform;
            Gizmos.DrawWireSphere(attackOrigin.position, PlayerStateMachine.PlayerCharacter.CurrentWeapon.Radius);
        }
    }
}