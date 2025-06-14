using RPGMechanics.Debugging;
using RPGMechanics.Weapons;

using UnityEngine;

namespace RPGMechanics.StateMachines.Player
{
    public class PlayerAttackState : PlayerBaseState
    {
        // TODO: These can probably go on the weapon
        private float attackDuration = 1.0f;
        private float timeElapsed;
        private bool hasDealtDamage = false;

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
            hasDealtDamage = false;
            PlayerStateMachine.PlayerCharacter.Animator.SetBool(IsAttacking, true);
            timeElapsed = 0;
            Attack();
        }

        public override void Tick(float deltaTime)
        {
            // Add logic for attacking
            timeElapsed += deltaTime;

            if (timeElapsed >= attackDuration)
            {
                // TODO: A next function would be so much better than this
                SwitchState(new PlayerFreeLookState(PlayerStateMachine));
            }
        }

        public override void Exit()
        {
            PlayerStateMachine.PlayerCharacter.InputReader.IsAttacking = false;
            PlayerStateMachine.PlayerCharacter.Animator.SetBool(IsAttacking, false);
        }

        public void Attack()
        {
            if (hasDealtDamage) return;

            Weapon currentWeapon = PlayerStateMachine.PlayerCharacter.CurrentWeapon;
            Transform playerTransform = PlayerStateMachine.PlayerCharacter.transform;
            Vector3 direction = playerTransform.forward;
            Vector3 origin = currentWeapon.transform.position + (direction * currentWeapon.Range);

            origin.y = 1.5f;
            Debug.DrawRay(origin,direction, Color.cyan, 1f);
                
            var success = Physics.SphereCast(
                origin,
                currentWeapon.Radius,
                direction,
                out hit,
                currentWeapon.Range,
                hitLayerMask
            );


            if (!success) { return; }

            DebugDrawManager.Instance?.DrawWireSphere(
                origin,
                currentWeapon.Radius,
                Color.red
            );
            
            Debug.Log("Running");

            var enemy = hit.collider.GetComponent<Characters.Enemies.Enemy>();
            if (enemy)
            {
                var remainingHealth = enemy.TakeDamage(currentWeapon.Damage);
                Debug.Log(remainingHealth);
                hasDealtDamage = true;
            }
        }
    }
}