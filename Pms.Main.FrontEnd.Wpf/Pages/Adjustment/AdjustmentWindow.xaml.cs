﻿using Microsoft.Extensions.Configuration;
using Pms.Timesheets.Domain.SupportTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pms.Main.FrontEnd.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AdjustmentWindow : Window
    {

        private readonly CollectionViewSource CutoffViewSource;
        //private readonly CutoffService CutoffService;

        public AdjustmentWindow()
        {
            InitializeComponent();

            CutoffViewSource = (CollectionViewSource)FindResource(nameof(CutoffViewSource));
            //CutoffService = new();
            //CutoffViewSource.Source = CutoffService.GetCutoffs();
        }

        public AdjustmentWindow(Cutoff cutoff, IConfigurationRoot? conf)
        {
            InitializeComponent();
            Shared.Configuration = conf;
            CutoffViewSource = (CollectionViewSource)FindResource(nameof(CutoffViewSource));

            //CutoffService = new();
            //CutoffViewSource.Source = CutoffService.GetCutoffs();

            //Shared.DefaultCutoff = cutoff;
            //CbPayrollDate.SelectedItem = cutoff;
            //CbPayrollDate.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Shared.DefaultPayRegister = null;
            //CbPayrollCode.SelectedItem = null;

            //BtnBilling.IsChecked = true;
        }



        private void BtnRecord_Checked(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new AdjustmentRecord());
        }

        private void BtnBilling_Checked(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new AdjustmentBilling());
        }
         
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Refresh();
        }

        private void CbPayrollDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && e.AddedItems[0] is not null)
            {
                //Shared.DefaultCutoff = (Cutoff)e.AddedItems[0];
                //frmMain.Refresh();
            }

        }

        private void CbPayrollCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems is not null && e.AddedItems.Count > 0 && e.AddedItems[0] is not null)
            {
                //Shared.DefaultPayRegister = (PayRegister)e.AddedItems[0];
                //frmMain.Refresh();
            }
        }

        private void BtnGovernment_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}