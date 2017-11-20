using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace rts_attempt
{
	class GameObject
	{
		private Texture2D texture { get; set; }
		private Vector2 positon { get; set; }
		private Rectangle sourceRectangle { get; set; }
		private Color tint { get; set; }
		private float angle { get; set; }
		private Vector2 origin { get; set; }
		private float scale { get; set; }
		private SpriteEffect effects { get; set; }
		private int depth { get; set; }

		SpriteBatch spriteBatch;

		public GameObject(Texture2D texture, Vector2 position, Rectangle sourceRectangle,
			Color tint, float angle, Vector2 origin, float scale, SpriteEffect spriteEffects, int layerDepth)
		{
			this.texture = texture;
			this.positon = position;
			this.sourceRectangle = sourceRectangle;
			this.tint = tint;
			this.angle = angle;
			this.origin = origin;
			this.scale = scale;
			this.effects = spriteEffects;
			this.depth = layerDepth;
			
		}
		public void Update(GameTime gameTime)
		{

		}
		public void Draw(GameTime gameTime)
		{

		}
	}
}
