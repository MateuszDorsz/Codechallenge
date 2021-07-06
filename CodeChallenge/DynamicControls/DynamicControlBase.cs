using CodeChallenge.DrawingLogic;
using CodeChallenge.DrawingProperties;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CodeChallenge.DynamicControls
{
    public class DynamicControlBase : Shape
    {
        public DynamicControlBase()
        {
            StrokeThickness = 3;
            Opacity = 0.5;
        }
        protected override Geometry DefiningGeometry
        {
            get
            {
                if(DrawingLogic != null)
                {
                    var brush = (SolidColorBrush)new BrushConverter().ConvertFrom(DrawingProperties.Color.ToString());
                    Stroke = brush;
                    if(DrawingProperties is IFillable && (DrawingProperties as IFillable).Fill)
                    {
                        Fill = brush;
                    }
                    return DrawingLogic.Draw(DrawingProperties);
                }
                return DefaultGeometry();
            }
        }

        public static readonly DependencyProperty DrawingLogicProperty
            = DependencyProperty.Register("DrawingLogic", typeof(IDrawingLogic), typeof(DynamicControlBase));

        public IDrawingLogic DrawingLogic
        {
            get { return (IDrawingLogic)GetValue(DrawingLogicProperty); }
            set 
            { 
                SetValue(DrawingLogicProperty, value);
            }
        }

        public static readonly DependencyProperty DrawingPropertiesProperty
            = DependencyProperty.Register("DrawingProperties", typeof(IDrawingProperties), typeof(DynamicControlBase));

        public IDrawingProperties DrawingProperties
        {
            get { return (IDrawingProperties)GetValue(DrawingPropertiesProperty); }
            set { SetValue(DrawingPropertiesProperty, value); }
        }

        public static readonly DependencyProperty InvalidateLayoutProperty
            = DependencyProperty.Register("InvalidateLayout", typeof(bool), typeof(DynamicControlBase));

        private Geometry DefaultGeometry()
        {
            StreamGeometry geometry = new StreamGeometry();
            return geometry;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            MessageBox.Show("Clicked");
        }
    }
}
