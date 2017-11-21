using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rts_attempt
{
	public class GameWorld
	{
		private List<GameObject> Objects = new List<GameObject>();

		public void Spawn(GameObject obj)
		{
			obj.World = this;
			Objects.Add(obj);
		}

		public void Update(GameTime gameTime)
		{
			foreach (var obj in Objects)
				if (obj.State == UpdateState.FullUpdate || obj.State == UpdateState.UpdateOnly)
					obj.PreUpdate(gameTime);
			foreach (var obj in Objects)
				if (obj.State == UpdateState.FullUpdate || obj.State == UpdateState.UpdateOnly)
					obj.Update(gameTime);
			foreach (var obj in Objects)
				if (obj.State == UpdateState.FullUpdate || obj.State == UpdateState.UpdateOnly)
					obj.PostUpdate(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
		{
			spriteBatch.Begin();
			foreach (var obj in Objects)
				if (obj.State == UpdateState.FullUpdate)
					obj.PreDraw(spriteBatch, gameTime);
			foreach (var obj in Objects)
				if (obj.State == UpdateState.FullUpdate)
				obj.Draw(spriteBatch, gameTime);
			foreach (var obj in Objects)
				if (obj.State == UpdateState.FullUpdate)
				obj.PostDraw(spriteBatch, gameTime);
			spriteBatch.End();
		}
	}
}
