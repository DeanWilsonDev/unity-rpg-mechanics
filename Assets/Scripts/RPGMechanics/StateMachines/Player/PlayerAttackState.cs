using RPGMechanics.Debugging;
using RPGMechanics.Weapons;

using UnityEngine;

namespace RPGMechanics.StateMachines.Player
{
    public class PlayerAttackState : PlayerBaseState
    {
        // TODO: These can probably go on the weapon
        private float attackDuration = 1.0f;
        private float attackStartTime;
        
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
            attackStartTime = Time.time;
            PlayerStateMachine.PlayerCharacter.Animator.SetBool(IsAttacking, true);
            Attack();
        }

        public override void Tick(float deltaTime)
        {
            // Add logic for attacking
            //Debug.Log("Attack State Tick");

            if (Time.time - attackStartTime >= attackDuration)
            {
                // TODO: A next function would be so much better than this
                SwitchState(new PlayerFreeLookState(PlayerStateMachine));
            }
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

            Debug.Log("Attacking");

            DebugDrawManager.Instance?.DrawWireSphere(
                attackOrigin.position,
                PlayerStateMachine.PlayerCharacter.CurrentWeapon.Radius,
                Color.red
            );

            if (!success) { return; }

            Debug.Log($"Hit: {hit.collider.name}");
            var enemy = hit.collider.GetComponent<Characters.Enemies.Enemy>();
            if (enemy)
            {
                enemy.TakeDamage(currentWeapon.Damage);
            }
        }
    }
}