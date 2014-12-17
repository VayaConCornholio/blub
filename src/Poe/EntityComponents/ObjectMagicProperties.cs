using System.Collections.Generic;
using PoeHUD.Framework;
using PoeHUD.Game;
using System;

namespace PoeHUD.Poe.EntityComponents
{
	public class ObjectMagicProperties : Component
	{
		public Rarity Rarity
		{
			get
			{
				if (Address != 0)
				{
					return (Rarity)M.ReadInt(Address + 40 + 0x18);
				}
				return Rarity.White;
			}
		}

		public List<string> Mods
		{
			get
			{
				if (this.Address == 0)
				{
					return new List<string>();
				}
                //for (var offset = 0; offset <= 128; offset++)
                //{
                //    var __begin = this.M.ReadInt(this.Address + offset);
                //    var __end = this.M.ReadInt(this.Address + offset + 4);
                //    var __amount = (__end - __begin) / 24;

                //    Console.WriteLine(offset.ToString() + ": " + __amount);
                //}
				int begin = this.M.ReadInt(this.Address + 84);
				int end = this.M.ReadInt(this.Address + 88);
				List<string> list = new List<string>();
				if (begin == 0 || end == 0)
				{
					return list;
				}
				for (int i = begin; i < end; i += 24)
				{
					string item = this.M.ReadStringU(this.M.ReadInt(i + 20, 0), 256, true);
					list.Add(item);
				}
				return list;
			}
		}
	}
}
