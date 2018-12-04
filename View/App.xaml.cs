using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using zLib;
using GenealogyResearchApp.ViewModel;

namespace GenealogyResearchApp.View {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    public partial class App : Application, INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged(string propertyName) {
			// take a copy to prevent thread issues
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) {
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private MainViewModel mainViewModel;
        public MainViewModel MainViewModel { get { return mainViewModel; } set { mainViewModel = value; RaisePropertyChanged("MainViewModel"); } }

        private bool mainViewModelReady;


		public bool MainViewModelReady { get { return mainViewModelReady; } set { mainViewModelReady = value; } }

        protected override void OnStartup(StartupEventArgs e) {

            System.Threading.Thread.CurrentThread.CurrentUICulture =
            new System.Globalization.CultureInfo("lv");

            MainWindow =  new MainWindow();
            MainWindow.Resources = Resources;
            MainWindow.Show();

			//InitAsync();
			//var a = 0;
			//a++;

			Thread w = new Thread(() => {
				MainViewModel = new MainViewModel(true);
				MainViewModelReady = true;
			});
			w.Name = "MainViewModel Loader";
			w.Start();

			bool exit = false;
			while (!exit) {
				Thread.Sleep(5);
				if (mainViewModelReady) {
					MainWindow.DataContext = MainViewModel;
					exit = true;
				}
			}

		}

		async public void InitAsync() {
			var t = new Task<MainViewModel>(() => new MainViewModel(true));
			MainViewModel = await t;
			MainWindow.DataContext = MainViewModel;
		}

        protected override void OnExit(ExitEventArgs e) {
			if (MainViewModel != null) MainViewModel.Save();
            base.OnExit(e);
        }
    }
}
