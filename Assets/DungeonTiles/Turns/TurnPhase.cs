using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonTiles.Turns
{
    /// <summary>
    /// The current phase in the turn it is.
    /// </summary>
    public enum TurnPhase
    {
        /// <summary>
        /// <b>Hero Phase</b>
        /// <p>
        /// Where the hero does the bulk of their actions.<br />
        /// In the hero phase the player may move->attack, attack->move or move->move.<br />
        /// There are also various other actions a player may undertake in the hero phase.
        /// </p>
        /// </summary>
        Hero,

        /// <summary>
        /// <b>Exploration Phase</b><br />
        /// <p>
        /// If the player on the edge of a tile, a new tile is generated, and a monster is (usually) spawned on the new tile.
        /// </p>
        /// </summary>
        Exploration,

        /// <summary>
        /// <b>Villian Phase</b>
        /// <p>
        /// If the player is <i>not</i> on the edge of a tile, or if the newly drawn tile is an encounter type tile, we trigger a random encounter.<br />
        /// Then all villians are activated. All player owned traps and monsters are then activated in the order they were drawn.
        /// </p>
        /// <p>
        /// After the villian phase it becomes the next players turn.
        /// </p>
        /// </summary>
        Villian
    }
}
