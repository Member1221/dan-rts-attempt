using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rts_attempt
{
	/// <summary>
	/// A game object that has entity functions (health, etc.)
	/// </summary>
	public abstract class GameEntity : GameObject
	{
		public int Health { get; set; }

		public List<GameEntityBehaviour<GameEntity>> Behaviours = new List<GameEntityBehaviour<GameEntity>>();


		public override void Update(GameTime gameTime)
		{
			foreach (var behaviour in Behaviours)
				behaviour.PreUpdate(this, gameTime);
			foreach (var behaviour in Behaviours)
				behaviour.Update(this, gameTime);
			foreach (var behaviour in Behaviours)
				behaviour.PostUpdate(this, gameTime);
		}
	}
}
