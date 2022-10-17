
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Interfaces;
using Sprites;
using System.Data.Common;
using Microsoft.Xna.Framework;
using System.Runtime.CompilerServices;
using Sprint0;
using System.Xml.Linq;

namespace LegendofZelda.SpriteFactories
{
    public class EnemyAndNPCSpriteFactory : ISpriteFactory
    {
        private Texture2D enemySpriteSheet;
        private Texture2D oldManSpriteSheet;
        private Texture2D bossSpriteSheet;
        private static EnemyAndNPCSpriteFactory instance = new EnemyAndNPCSpriteFactory();
        

        public static EnemyAndNPCSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private EnemyAndNPCSpriteFactory()
        {
        }


        public void loadContent(ContentManager content)
        {
            enemySpriteSheet = content.Load<Texture2D>("enemies");
            oldManSpriteSheet = content.Load<Texture2D>("oldman");
            bossSpriteSheet = content.Load<Texture2D>("bosses");

        }


        public ISprite CreateEnemyOrNPC(Vector2 location, string name)
        {

            switch (name)
            {
                case "Goriya":

                    return new GoriyaSprite(enemySpriteSheet, 600, 250);

                case "Keese":

                    return new KeeseSprite(enemySpriteSheet, 600, 250);

                case "Stalfos":

                    return new StalfosSprite(enemySpriteSheet, 600, 250);

                case "Gel":

                    return new GelSprite(enemySpriteSheet, 600, 250);

                case "DragonBoss":

                    return new DragonBossSprite(enemySpriteSheet, 600, 250);

                case "OldMan":

                    return new OldManSprite(enemySpriteSheet, 600, 250);

                default:

                    return null;
            }

        }

    }
}