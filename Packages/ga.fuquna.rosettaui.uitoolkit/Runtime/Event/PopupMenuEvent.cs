﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace RosettaUI.UIToolkit
{
    public class PopupMenuEvent : EventBase<PopupMenuEvent>
    {
        public Vector2 Position { get; protected set; }
        public List<MenuItem> MenuItems { get; } = new();
        
        
        public static void Send(VisualElement visualElement, Vector2 position)
        {
            using var evt = GetPooled();
            
            evt.target = visualElement;
            evt.Position = position;
            evt.MenuItems.Clear();
            
            visualElement.SendEvent(evt);
        }
        
        protected override void Init()
        {
            base.Init();
            tricklesDown = true;
            bubbles = true;
        }
    }
}