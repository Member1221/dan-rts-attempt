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
		public Background(Texture2D texture, Vector2 position, Rectangle sourceRectangle, Color tint, float angle, Vector2 origin, float scale, SpriteEffect spriteEffects, int layerDepth) : base(texture, position, sourceRectangle, tint, angle, origin, scale, spriteEffects, layerDepth)
		{

		}

		public void Update()
		{
			
		}
		public void Draw()
		{
			
		}
	}
}
