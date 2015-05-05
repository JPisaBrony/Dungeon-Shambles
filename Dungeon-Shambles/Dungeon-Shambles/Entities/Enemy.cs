using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonShambles
{
    public class Enemy
    {
        // create a texture for the character
        protected TextureImporter enemyImage = new TextureImporter();
        protected Double health;

        // character x and y position
        protected float x, y;
        // character movement speed can only be multiples of 2
        protected float speed;

        public Enemy(String image, float inputX, float inputY)
        {
            enemyImage.importTexture(image);
            this.x = inputX;
            this.y = inputY;
            speed = 0.015f;
            health = 5;
        }

        public void renderEnemy()
        {
            enemyImage.renderTexture(0.15f, this.x, this.y);
        }

        public void chase(GameEntities target)
        {
            if (target.getX() > x) this.x += speed;
            else if (target.getX() + speed < x) this.x -= speed;
            else
            {
                if (target.getY() > y) this.y += speed;
                else if (target.getY() + speed < y) this.y -= speed;
            }
        }       
    }
}
