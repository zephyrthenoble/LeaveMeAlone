﻿#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.Diagnostics;
#endregion

namespace LeaveMeAlone
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class LeaveMeAlone : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Character boss;
        public enum GameState { Main, Upgrade, Lair, Battle, Quit };
        public static GameState gamestate = GameState.Main;
        int seed = 1000;
        public static Random random = new Random(1000);
        public LeaveMeAlone()
            : base() 
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            //graphics.PreferredBackBufferHeight = 480;   // set this value to the desired height of your window

        }
        

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// 

        protected override void Initialize()
        {
            base.Initialize();
            //graphics.ToggleFullScreen();
            //graphics.ApplyChanges();

            IsMouseVisible = true;
            this.Window.Title = "Leave Me Alone";

            //Skill s = new Skill("test", 1, 100, 1, 0, 0, "My first skill", new Skill.Run(test));
            //s.runnable(boss_char);
                        MainMenu.init();
            SkillTree.Init();
            PartyManager.Init();
            

            BattleManager.heroes = PartyManager.CreateParty();
            for (int i = 0; i < BattleManager.heroes.Count; i++)
            {
                BattleManager.heroes[i].Init();
            }


            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //RenderTarget2D target = new RenderTarget2D(GraphicsDevice, 800, 480);
            //GraphicsDevice.SetRenderTarget(target);

            MainMenu.loadContent(Content);
            MenuBoss.LoadContent(Content);
            UpgradeMenu.loadContent(Content);
            Character.load_content(Content);
            Status.LoadContent(Content);
            BattleManager.LoadContent(Content);
            SkillTree.LoadContent(Content);
            Text.loadContent(Content);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            switch (gamestate)
            {
                case GameState.Main:
                    gamestate = MainMenu.Update(gameTime);
                    break;
                case GameState.Upgrade:
                    //upgrade_menu
                    gamestate = UpgradeMenu.Update(gameTime);
                    break;
                case GameState.Lair:
                    //Lair menu
                    break;
                case GameState.Battle:
                    gamestate = BattleManager.Update(gameTime);
                    break;
                case GameState.Quit:
                    Exit();
                    break;
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //RenderTarget2D target = new RenderTarget2D(GraphicsDevice, 800, 480);
            //GraphicsDevice.SetRenderTarget(target);

            switch (gamestate)
            {
                case GameState.Main:
                    MainMenu.Draw(spriteBatch);
                    break;
                case GameState.Upgrade:
                    //upgrade_menu
                    UpgradeMenu.Draw(spriteBatch);
                    break;
                case GameState.Lair:
                    //Lair menu
                    break;
                case GameState.Battle:
                    BattleManager.Draw(spriteBatch);
                    break;
            }
            //spriteBatch.End();
            //GraphicsDevice.SetRenderTarget(null);
            //spriteBatch.Begin();
            //spriteBatch.Draw(target, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}