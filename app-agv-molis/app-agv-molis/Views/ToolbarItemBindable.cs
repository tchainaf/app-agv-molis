using Xamarin.Forms;

namespace app_agv_molis.Views
{
    class ToolbarItemBindable : ToolbarItem
    {
        public static readonly BindableProperty IsVisibleProperty = BindableProperty.Create(nameof(IsVisible), typeof(bool), typeof(ToolbarItemBindable), true, BindingMode.TwoWay, propertyChanged: OnIsVisibleChanged);

        public bool IsVisible
        {
            get => (bool)GetValue(IsVisibleProperty);
            set => SetValue(IsVisibleProperty, value);
        }

        private static void OnIsVisibleChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var item = bindable as ToolbarItemBindable;

            if (item == null || item.Parent == null)
                return;

            var toolbarItems = ((ContentPage)item.Parent).ToolbarItems;

            if ((bool)newvalue && !toolbarItems.Contains(item))
            {
                Device.BeginInvokeOnMainThread(() => { toolbarItems.Add(item); });
            }
            else if (!(bool)newvalue && toolbarItems.Contains(item))
            {
                Device.BeginInvokeOnMainThread(() => { toolbarItems.Remove(item); });
            }
        }
    }
}
