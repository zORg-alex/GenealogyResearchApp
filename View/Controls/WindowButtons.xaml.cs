using System.Windows;
using System.Windows.Controls;

namespace GenealogyResearchApp.View.Controls {
	/// <summary>
	/// Interaction logic for WindowButtons.xaml
	/// </summary>
	public partial class WindowButtons : UserControl {
		
		public WindowButtons() {
			InitializeComponent();
		}

        Window window { get { return Window.GetWindow(this); } }

        private void CloseButton_Click(object sender, RoutedEventArgs e) {
            SystemCommands.CloseWindow(window);
        }
        private void MaximizeButton_Click(object sender, RoutedEventArgs e) {
            SystemCommands.MaximizeWindow(window);
        }
        private void RestoreButton_Click(object sender, RoutedEventArgs e) {
            SystemCommands.RestoreWindow(window);
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e) {
            SystemCommands.MinimizeWindow(window);
        }
    }
}
