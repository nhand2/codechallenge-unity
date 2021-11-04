namespace Platformer.Mechanics
{
    using Platformer.Gameplay;
    using UnityEngine;
    using static Platformer.Core.Simulation;

    /// <summary>
    /// Marks a trigger as a VictoryZone, usually used to end the current game level.
    /// </summary>
    public class VictoryZone : MonoBehaviour
    {
        /// <summary>
        /// The trophy animator.
        /// </summary>
        [SerializeField]
        private Animator trophyAnimator;

        /// <summary>
        /// The trophy win animator hash.
        /// </summary>
        private int trophyWinHash = Animator.StringToHash("win");

        /// <summary>
        /// The Unity on trigger enter 2d.
        /// </summary>
        /// <param name="collider">The other game object collider.</param>
        private void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                var ev = Schedule<PlayerEnteredVictoryZone>();
                ev.victoryZone = this;
                trophyAnimator.SetTrigger(trophyWinHash);
            }
        }
    }
}