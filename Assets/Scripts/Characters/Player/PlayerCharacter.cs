using UnityEngine;

namespace Characters.Player
{
    public class PlayerCharacter: Character
    {
        
        [SerializeField] private PlayerInventory inventory;
        
        public PlayerInventory Inventory => inventory;
        
        protected override void Start()
        {
            base.Start();
        }
        
        public override void KillCharacter()
        {
            throw new System.NotImplementedException();
        }
    }
}