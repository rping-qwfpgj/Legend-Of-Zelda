using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0;
using Interfaces;
using SharpDX.Direct3D9;
using Commands;

namespace Controllers
{
	public class KeyboardController : IController
	{
		private Dictionary<Keys, ICommand> keyBindings = new Dictionary<Keys, ICommand>();
		private ICommand noInput;
		private ICommand previousCommand;
		

        // Pass the noInput command into the keyboard controller in Game1's initialize function
        public KeyboardController(ICommand command) 
		{
			this.noInput = command;
			this.previousCommand = command;
		}

		public void AddCommand(Keys key, ICommand command)
		{
			this.keyBindings.Add(key, command);

		}

		public void Update()
		{ 
			KeyboardState kstate = Keyboard.GetState();

			if(kstate.GetPressedKeyCount() == 0)
			{
				this.noInput.Execute();
				previousCommand = this.noInput;
			} 
			else
			{
                // Loop through the bindings. If a key is down, execute its command.
                foreach (Keys key in keyBindings.Keys)
                {
                    if (kstate.IsKeyDown(key))
                    {
						Type typeField = previousCommand.GetType();
						if (typeField != keyBindings[key].GetType())
						{
							keyBindings[key].Execute();
						}
                        previousCommand = keyBindings[key];
                    }
                }
            }			
		}
    }

    public class MouseController : IController
    {
        private Vector2 center;
        private Game1 myGame;

        public MouseController(Game1 game, Vector2 vector)
        {
            center = vector;
            myGame = game;
        }

        public void Update()
        {
            MouseState state = Mouse.GetState();

            if (state.LeftButton == ButtonState.Pressed)
            {
                if (state.X < center.X) //upper left
                {
                    new PreviousRoomCommand(myGame.currentRoom, myGame.rooms, myGame.currentRoomIndex).Execute();
                }
                else if (state.X > center.X )//upper right
                {
                    new NextRoomCommand(myGame.currentRoom, myGame.rooms, myGame.currentRoomIndex).Execute();
                }

            }

        }

    }
}


