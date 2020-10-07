﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace PaintPassing
{
    public class VisualHost : FrameworkElement
    {
        private readonly VisualCollection _children;

        public VisualHost()
        {
            _children = new VisualCollection(this);
        }

        protected override int VisualChildrenCount => _children.Count;

        public void AddChild(DrawingVisual drawingVisual)
        {
            _children.Add(drawingVisual);
        }

        public void RemoveLastChild()
        {
            _children.RemoveAt(VisualChildrenCount - 1);
        }

        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _children.Count) throw new System.ArgumentOutOfRangeException();

            return _children[index];
        }

        public void Redraw(List<Shape> shapes)
        {
            _children.Clear();

            var drawingVisual = new DrawingVisual();
            using (var dc = drawingVisual.RenderOpen())
            {
                //dc.DrawRectangle();
                foreach (var shape in shapes) shape.Draw(dc);
            }
            
            _children.Add(drawingVisual);
        }
    }
}