using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Visual_Rugby.Views
{
    public partial class DataTableView : UserControl
    {
        public DataTableView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
