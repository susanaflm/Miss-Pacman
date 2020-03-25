﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MsPacMan
{
    public class Pellet : DrawableGameComponent
    {
        #region variables

        private Texture2D texture;

        private SpriteBatch spriteBatch;

        private Game1 game1;

        private Board board;

        private Point position;

        public static bool powerPellet = false;

        #endregion

        #region constructor

        public Pellet(Game1 game, int x, int y) : base(game)
        {
            position.X = x;

            position.Y = y;

            game1 = game;

            spriteBatch = game.SpriteBatch;

            texture = game.SpriteSheetMap;

        }

        public override void Update(GameTime gameTime)
        {

            Rectangle playerPosition = new Rectangle(game1.Player.position, new Point(16));

            Rectangle PelletArea = new Rectangle(((position.ToVector2()) * Game1.outputTileSize).ToPoint(), new Point(20));


            if (PelletArea.Intersects(playerPosition))
            {
                powerPellet = true;
                game1.Components.Remove(this);

                game1.Pellets.Remove(this);

            }
        }

        public static void GetPelletStatus()
        {
            if (powerPellet == true)
            {
                powerPellet = true;
            }
            
            
        }
        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();

            Rectangle outRect = new Rectangle(position.X * Game1.outputTileSize, position.Y * Game1.outputTileSize, Game1.outputTileSize, Game1.outputTileSize);

            Rectangle PowerPellets = new Rectangle(15 * 35, 4 * 35, 35, 35);
            spriteBatch.Draw(texture, outRect, PowerPellets, Color.White);
            

            spriteBatch.End();
        }
        #endregion

    }
}