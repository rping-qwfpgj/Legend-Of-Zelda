﻿using System;
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
		private ICommand currentCommand;
		

        // Pass the noInput command into the keyboard controller in Game1's initialize function
        public KeyboardController(ICommand command) 
		{
			this.noInput = command;
			this.currentCommand = command;
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
				currentCommand = this.noInput;
			} 
			else
			{
                // Loop through the bindings. If a key is down, execute its command.
                foreach (Keys key in keyBindings.Keys)
                {
                    if (kstate.IsKeyDown(key))
                    {
						Type typeField = currentCommand.GetType();
						if (typeField != keyBindings[key].GetType())
						{
							keyBindings[key].Execute();
						}
                        currentCommand = keyBindings[key];
                    }
                }
            }			
		}
	}


}
	

