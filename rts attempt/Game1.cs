using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

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

		GameWorld world;

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
			Window.AllowUserResizing = true;
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

			world = new GameWorld();

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
			ContentMgr.setCManager(Content);
			background = ContentMgr.LoadContent<Texture2D>("Images/stars");
			shuttle = ContentMgr.LoadContent<Texture2D>("Images/shuttle");
			earth = ContentMgr.LoadContent<Texture2D>("Images/earth");
			font = ContentMgr.LoadContent<SpriteFont>("Fonts/Score");

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

			world.Update(gameTime);

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


			Vector2 locationEarth = new Vector2(400, 240);

			Rectangle sourceEarth = new Rectangle(0, 0, earth.Width, earth.Height);
			Rectangle sourceShuttle = new Rectangle(0, 0, earth.Width, earth.Height);
			Vector2 originEarth = new Vector2(earth.Width / 2, earth.Height / 2);
			Vector2 originShuttle = new Vector2(shuttle.Width / 2, shuttle.Height / 2);

			spriteBatch.Draw(earth, locationEarth, sourceEarth, Color.White, angle, originEarth, 1.0f, SpriteEffects.None, 1);
			spriteBatch.Draw(shuttle, mouse.Position.ToVector2(), sourceShuttle, Color.White, angle, originShuttle, 1.0f, SpriteEffects.None, 1);
			spriteBatch.DrawString(font, "Score " + score, new Vector2(100, 100), Color.White);


			world.Draw(spriteBatch, gameTime);

            base.Draw(gameTime);
        }
    }

	public class ContentMgr
	{
		private static ContentManager mgr;
		private static Dictionary<string, object> content = new Dictionary<string, object>();

		/// <summary>
		/// Sets the content manager, do not run this outside of the main game class.
		/// </summary>
		/// <param name="man">Man.</param>
		internal static void setCManager(ContentManager man)
		{
			mgr = man;
		}

		/// <summary>
		/// Loads the content of type T.
		/// </summary>
		/// <returns>The content.</returns>
		/// <param name="name">Name</param>
		/// <param name="unique">If set to <c>true</c> a unique copy of the item will be made.</param>
		/// <typeparam name="T">The type to load</typeparam>
		public static T LoadContent<T>(string name, bool unique = false)
		{
			if (unique)
				return mgr.Load<T>(name);
			if (content.ContainsKey(name)) return (T)content[name];
			content[name] = mgr.Load<T>(name);
			return (T)content[name];
		}
	}
}
