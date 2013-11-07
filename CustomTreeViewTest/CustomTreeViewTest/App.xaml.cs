using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CustomTreeViewTest
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private static Mutex mutex;


        protected override void OnExit(ExitEventArgs e)
        {
            if (App.mutex == null)
            { 
                return;
            }

            App.mutex.ReleaseMutex();
            App.mutex.Close();
            App.mutex = null;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            App.mutex = new Mutex(false, "CustomTreeViewTest-{4CF34BFB-5473-4C98-A401-8B4AD940A34E}");
            if (!App.mutex.WaitOne(0, false))
            {
                App.mutex.Close();
                App.mutex = null;

                this.Shutdown();
                return;
            }

            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
