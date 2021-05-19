using app_agv_molis.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace app_agv_molis.Views
{
    public class StepProgressBarControl : StackLayout
    {
        Button _lastStepSelected;
        public static readonly BindableProperty StepsProperty = BindableProperty.Create(nameof(Steps), typeof(string), typeof(StepProgressBarControl), "");
        public static readonly BindableProperty StepSelectedProperty = BindableProperty.Create(nameof(StepSelected), typeof(string), typeof(StepProgressBarControl), "", defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty StepColorProperty = BindableProperty.Create(nameof(StepColor), typeof(Color), typeof(StepProgressBarControl), Color.White, defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty StepsNameProperty = BindableProperty.Create(nameof(StepsName), typeof(ObservableCollection<string>), typeof(StepProgressBarControl), new ObservableCollection<string>(), defaultBindingMode: BindingMode.TwoWay);

        public Color StepColor
        {
            get { return (Color)GetValue(StepColorProperty); }
            set { SetValue(StepColorProperty, value); }
        }

        public string Steps
        {
            get { return (string)GetValue(StepsProperty); }
            set { SetValue(StepsProperty, value); }
        }

        public string StepSelected
        {
            get { return (string)GetValue(StepSelectedProperty); }
            set { SetValue(StepSelectedProperty, value); }
        }

        public ObservableCollection<string> StepsName
        {
            get { return (ObservableCollection<string>)GetValue(StepsNameProperty); }
            set { SetValue(StepsNameProperty, value); }
        }


        public StepProgressBarControl()
        {
            Orientation = StackOrientation.Vertical;
            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.Start;
            Padding = new Thickness(10, 0);
            Spacing = 0;
            AddStyles();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            try
            {
                if (propertyName == StepsProperty.PropertyName)
                {
                    SetStepsAsync();
                }
                else if (propertyName == StepSelectedProperty.PropertyName)
                {
                    var children = this.Children.First(p => !string.IsNullOrEmpty(p.ClassId) && p.ClassId == StepSelected);
                    if (children != null) SelectElement(children as Button);

                }
                else if (propertyName == StepColorProperty.PropertyName)
                {
                    AddStyles();
                }
            }
            catch (Exception ex)
            {
                
                Debug.WriteLine(ex);
            }
        }

        private void SetStepsAsync()
        {
            SetSteps();
            for (int i = 0; i < StepsName.Count; i++)
            {
                var button = new Button()
                {
                    Text = StepsName[i],
                    ClassId = $"{i + 1}",
                    Style = Resources["unSelectedStyle"] as Style
                };

                this.Children.Add(button);

                if (i < StepsName.Count - 1)
                {
                    var separatorLine = new BoxView()
                    {
                        BackgroundColor = Color.Silver,
                        HeightRequest = 1,
                        WidthRequest = 5,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    };
                    this.Children.Add(separatorLine);
                }
            }
        }

        private void SetSteps()
        {
            var length = SecureStorage.GetAsync("zone-length").Result;
            for (int i = 0; i < Int32.Parse(length); i++)
            {
                StepsName.Add(SecureStorage.GetAsync($"zone-{i + 1}").Result);
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            SelectElement(sender as Button);
        }

        void SelectElement(Button elementSelected)
        {

            if (_lastStepSelected != null) _lastStepSelected.Style = Resources["unSelectedStyle"] as Style;

            elementSelected.Style = Resources["selectedStyle"] as Style;

            StepSelected = elementSelected.Text;
            _lastStepSelected = elementSelected;

        }

        void AddStyles()
        {
            var unselectedStyle = new Style(typeof(Button))
            {
                Setters = {
                    new Setter { Property = BackgroundColorProperty,   Value = Color.Transparent },
                    new Setter { Property = Button.BorderColorProperty,   Value = StepColor },
                    new Setter { Property = Button.TextColorProperty,   Value = StepColor },
                    new Setter { Property = Button.BorderWidthProperty,   Value = 0.5 },
                    new Setter { Property = Button.BorderRadiusProperty,   Value = 20 },
                    new Setter { Property = HeightRequestProperty,   Value = 65 },
                    new Setter { Property = WidthRequestProperty,   Value = 65 },
                    new Setter { Property = Button.FontSizeProperty,   Value = 12 }
            }
            };

            var selectedStyle = new Style(typeof(Button))
            {
                Setters = {
                    new Setter { Property = BackgroundColorProperty, Value = StepColor },
                    new Setter { Property = Button.TextColorProperty, Value = Color.White },
                    new Setter { Property = Button.BorderColorProperty, Value = StepColor },
                    new Setter { Property = Button.BorderWidthProperty,   Value = 0.5 },
                    new Setter { Property = Button.BorderRadiusProperty,   Value = 20 },
                    new Setter { Property = HeightRequestProperty,   Value = 65 },
                    new Setter { Property = WidthRequestProperty,   Value = 65 },
                    new Setter { Property = Button.FontAttributesProperty,   Value = FontAttributes.Bold },
                    new Setter { Property = Button.FontSizeProperty,   Value = 12 }
            }
            };

            Resources = new ResourceDictionary();
            Resources.Add("unSelectedStyle", unselectedStyle);
            Resources.Add("selectedStyle", selectedStyle);
        }
    }
}
