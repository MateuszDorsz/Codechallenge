using CodeChallenge.Data.Factory;
using CodeChallenge.Factory;
using CodeChallenge.Helpers;
using CodeChallenge.Model;
using CodeChallenge.Model.Conversion;
using CodeChallenge.Utils;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CodeChallenge.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IFileDataReaderFactory _fileDataReaderFactory;
        private readonly IShapesCollectionFactory _shapesCollectionFactory;
        private DynamicControlViewModelFactory _dynamicControlViewModelFactory;
        private readonly GridScalingHelper _gridScalingHelper;

        public MainWindowViewModel()
        {
            //ToDo - autofac?
            _fileDataReaderFactory = new FileDataReaderFactory();
            _shapesCollectionFactory = new ShapesCollectionFactory(new ColorParser(), new CoordinatesParser());
            _dynamicControlViewModelFactory = new DynamicControlViewModelFactory();
            OpenFileDialogCommand = new RelayCommand(OpenFileDialog);
            _gridScalingHelper = GridScalingHelper.GetInstance();
        }

        private string _inputFielPath = "Select file";
        public string InputFilePath
        {
            get => _inputFielPath;
            set
            {
                _inputFielPath = value;
                OnPropertyChanged();
            }
        }


        private ShapesCollection _shapesCollection;
        public ShapesCollection ShapesCollection
        {
            get
            {
                return _shapesCollection;
            }
            set
            {
                _shapesCollection = value;
                AddShapesViewModels(_shapesCollection);
                OnPropertyChanged();
                OnPropertyChanged(nameof(DynamicControls));
            }
        }

        private double _drawingGridHeight = 390;
        public double DrawingGridHeight
        {
            get
            {
                return _drawingGridHeight;
            }
            set
            {
                _drawingGridHeight = value;
                SetScaling();
                OnPropertyChanged();
            }
        }

        private double _drawingGridWidth = 800;
        public double DrawingGridWidth
        {
            get
            {
                return _drawingGridWidth;
            }
            set
            {
                _drawingGridWidth = value;
                SetScaling();
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DynamicControlViewModel> DynamicControls { get; set; }

        private void AddShapesViewModels(ShapesCollection shapesCollection)
        {
            SetScaling();
            DynamicControls = new ObservableCollection<DynamicControlViewModel>();
            foreach (var shape in shapesCollection.Shapes)
            {
                var control = _dynamicControlViewModelFactory.Create(shape);
                DynamicControls.Add(control);
            }
        }

        private void SetScaling()
        {
            if(ShapesCollection != null && ShapesCollection.Shapes.Count > 0)
            {
                _gridScalingHelper.SetScaling(DrawingGridWidth, DrawingGridHeight, ShapesCollection.MaxDimensionAbsolute);
            }
        }

        #region Commands

        public ICommand OpenFileDialogCommand { get; set; }
        private void OpenFileDialog(object obj)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

            dialog.Filter = "JSON files (.json)|*.json";

            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    InputFilePath = dialog.FileName;
                    var shapeProperties = _fileDataReaderFactory.GetReader(".json").GetShapeProperties(InputFilePath);
                    var shapesCollection = _shapesCollectionFactory.CreateShapesCollection(shapeProperties);
                    ShapesCollection = shapesCollection;
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

        #endregion
    }
}
