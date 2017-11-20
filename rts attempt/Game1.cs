using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace rts_attempt
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

		MouseState mouse;

		private Texture2D background;
		private Texture2D shuttle;
		private Texture2D earth;
		private SpriteFont font;
		private int score = 0;

		private float angle = 0;
		private float scale = 1.0f;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
			IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
			// TODO: Add your initialization logic here

			mouse = Mouse.GetState();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

			background = Content.Load<Texture2D>("Images/stars");
			shuttle = Content.Load<Texture2D>("Images/shuttle");
			earth = Content.Load<Texture2D>("Images/earth");
			font = Content.Load<SpriteFont>("Fonts/Score");

			// TODO: use this.Content to load your game content here
		}

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			mouse = Mouse.GetState();

			// TODO: Add your update logic here
			score++;
			//angle += 0.001f;
			
			///work out angle relative to mouse
			Vector2 mousePos = mouse.Position.ToVector2();
			Vector2 earthPos = new Vector2(400, 240);
			Vector2 difference = mousePos - earthPos;
			angle = (float)Math.Atan2(difference.Y, difference.X);

			//background move
			float distance = (float)Math.Sqrt(Math.Pow(earthPos.X - mousePos.X, 2) + Math.Pow(earthPos.Y - mousePos.Y, 2));
			if (distance < 0f)
				distance *= -1;

			scale = distance / 500 + 1;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			spriteBatch.Begin();
			spriteBatch.Draw(background, new Vector2(400, 240), new Rectangle(0, 0, background.Width, background.Height), Color.White, 0f, new Vector2(400, 240), scale, SpriteEffects.None, 0);

			Vector2 locationEarth = new Vector2(400, 240);

			Rectangle sourceEarth = new Rectangle(0, 0, earth.Width, earth.Height);
			Rectangle sourceShuttle = new Rectangle(0, 0, earth.Width, earth.Height);
			Vector2 originEarth = new Vector2(earth.Width / 2, earth.Height / 2);
			Vector2 originShuttle = new Vector2(shuttle.Width / 2, shuttle.Height / 2);

			spriteBatch.Draw(earth, locationEarth, sourceEarth, Color.White, angle, originEarth, 1.0f, SpriteEffects.None, 1);
			spriteBatch.Draw(shuttle, mouse.Position.ToVector2(), sourceShuttle, Color.White, angle, originShuttle, 1.0f, SpriteEffects.None, 1);
			spriteBatch.DrawString(font, "Score " + score, new Vector2(100, 100), Color.White);
			spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
