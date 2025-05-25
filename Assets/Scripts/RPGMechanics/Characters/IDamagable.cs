namespace RPGMechanics.Characters
{
    public interface IDamagable
    {
        /// <summary>
        ///     Used to affect the character's health by the damage taken.
        /// </summary>
        /// <param name="damage">The raw damage value pre damage calculation</param>
        /// <returns>Remaining Health</returns>
        public float TakeDamage(int damage);

        /// <summary>
        ///     Checks to see if the character is dead.
        /// </summary>
        /// <returns>true if the character is dead, false if alive</returns>
        public bool IsDead();


        /// <summary>
        ///     Kills the character.
        /// </summary>
        public void KillCharacter();
    }
}