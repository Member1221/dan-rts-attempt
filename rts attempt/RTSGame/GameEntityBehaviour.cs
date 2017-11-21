using System;
using Microsoft.Xna.Framework;

namespace rts_attempt
{
	public abstract class GameEntityBehaviour<T> where T : GameEntity
	{
		public virtual void PreUpdate(T parent, GameTime gameTime) { }
		public abstract void Update(T parent, GameTime gameTime);
		public virtual void PostUpdate(T parent, GameTime gameTime) { }
	}
}
