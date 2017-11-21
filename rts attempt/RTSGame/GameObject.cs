using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace rts_attempt
{
	public enum UpdateState
	{
		FullUpdate,
		UpdateOnly,
		Dead
	}

	public abstract class GameObject
	{
		public GameWorld World { get; set; }
		public UpdateState State { get; set; }

		public Vector2 Positon { get; set; }
		public Texture2D Texture { get; set; }
		public Rectangle SourceRectangle { get; set; }
		public Color Tint { get; set; }
		public float Angle { get; set; }
		public Vector2 Origin { get; set; }
		public float Scale { get; set; }
		public List<Effect> Effects { get; set; }
		public int Depth { get; set; }

		public GameObject()
		{
			
		}

		public GameObject(Texture2D texture, Vector2 position, Rectangle sourceRectangle,
			Color tint, float angle, Vector2 origin, float scale, Effect spriteEffects, int layerDepth)
		{
			this.Texture = texture;
			this.Positon = position;
			this.SourceRectangle = sourceRectangle;
			this.Tint = tint;
			this.Angle = angle;
			this.Origin = origin;
			this.Scale = scale;
			this.Effect = spriteEffects;
			this.Depth = layerDepth;
		}

		public void TriggerUpdate(SpriteBatch spriteBatch)
		{
			spriteBatch.Begin();
			spriteBatch.End();
		}

		public virtual void PreUpdate(GameTime gameTime) { }
		public abstract void Update(GameTime gameTime);
		public virtual void PostUpdate(GameTime gameTime) { }
		public virtual void PreDraw(SpriteBatch batch, GameTime gameTime) { }
		public abstract void Draw(SpriteBatch batch, GameTime gameTime);
		public virtual void PostDraw(SpriteBatch batch, GameTime gameTime) { }
	}
}
