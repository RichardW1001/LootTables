﻿namespace Loot
{
    public class Item
    {
        public Item(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
