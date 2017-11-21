using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rts_attempt.GameObjects
{
	class Background : GameObject
	{
		private float scale = 1f;

		public Background()
		{
			this.Texture = ContentMgr.LoadContent<Texture2D>("textures/stars");
		}

		public override void Draw(SpriteBatch batch, GameTime gameTime)
		{
			batch.Draw(this.Texture, new Vector2(400, 240), new Rectangle(0, 0, this.Texture.Width, this.Texture.Height), Color.White, 0f, new Vector2(400, 240), scale, SpriteEffects.None, 0);
		}

		public override void Update(GameTime gameTime)
		{
			//background move
			float distance = (float)Math.Sqrt(Math.Pow(earthPos.X - mousePos.X, 2) + Math.Pow(earthPos.Y - mousePos.Y, 2));
			if (distance < 0f)
				distance *= -1;

			scale = distance / 500 + 1;
		}
	}
}
