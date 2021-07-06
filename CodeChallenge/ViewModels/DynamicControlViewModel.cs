using CodeChallenge.DrawingLogic;
using CodeChallenge.DrawingProperties;

namespace CodeChallenge.ViewModels
{
    public class DynamicControlViewModel : ViewModelBase
    {
        public DynamicControlViewModel(IDrawingLogic drawingLogic, IDrawingProperties drawingProperties)
        {
            DrawingLogic = drawingLogic;
            DrawingProperties = drawingProperties;
        }

        public IDrawingLogic DrawingLogic { get; set; }
        public IDrawingProperties DrawingProperties {get;set;}
    }
}
