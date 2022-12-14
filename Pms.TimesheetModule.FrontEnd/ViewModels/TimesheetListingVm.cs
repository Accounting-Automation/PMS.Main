using Pms.Masterlists.Domain;
using Pms.TimesheetModule.FrontEnd.Commands;
using Pms.TimesheetModule.FrontEnd.Models;
using Pms.Timesheets.BizLogic.Concrete;
using Pms.Timesheets.Domain;
using Pms.Timesheets.Domain.SupportTypes;
using Pms.Timesheets.Persistence;
using Pms.Timesheets.ServiceLayer.Outputs;
using Pms.Timesheets.ServiceLayer.TimeSystem.Adapter;
using Pms.Timesheets.ServiceLayer.TimeSystem.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Pms.Timesheets.ServiceLayer.TimeSystem.Services.Enums;
using Pms.Main.FrontEnd.Common.Messages;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Pms.Masterlists.Domain.Enums;
using Pms.Main.FrontEnd.Common;

namespace Pms.TimesheetModule.FrontEnd.ViewModels
{
    public class TimesheetListingVm : ViewModelBase
    {
        #region Properties
        private DownloadOptions options = DownloadOptions.All;
        public DownloadOptions Options
        {
            get => options;
            set => SetProperty(ref options, value);
        }


        private IEnumerable<Timesheet> _timesheets;
        public IEnumerable<Timesheet> Timesheets
        {
            get => _timesheets;
            set => SetProperty(ref _timesheets, value);
        }

        #endregion

        public ICommand DownloadCommand { get; }
        public ICommand EvaluateCommand { get; }
        public ICommand ExportCommand { get; }


        public ICommand LoadTimesheets { get; }

        public ICommand DetailTimesheet { get; }

        public TimesheetListingVm(Models.Timesheets timesheets)
        {
            LoadTimesheets = new Listing(this, timesheets);

            DownloadCommand = new Download(this, timesheets);
            EvaluateCommand = new EvaluateAll(this, timesheets);
            ExportCommand = new Export(this, timesheets);
            DetailTimesheet = new Detail(timesheets);

            _timesheets = new ObservableCollection<Timesheet>();
            Timesheets = new ObservableCollection<Timesheet>();


            Site = WeakReferenceMessenger.Default.Send<CurrentSiteRequestMessage>();
            PayrollCode = WeakReferenceMessenger.Default.Send<CurrentPayrollCodeRequestMessage>();

            string cutoffId = WeakReferenceMessenger.Default.Send<CurrentCutoffIdRequestMessage>();
            if (!string.IsNullOrEmpty(cutoffId))
                Cutoff = new Cutoff(cutoffId);

            IsActive = true;
        }

        protected override void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            if ((new string[] { nameof(Site), nameof(PayrollCode), nameof(Cutoff) }).Any(p => p == e.PropertyName))
                LoadTimesheets.Execute(null);

            base.OnPropertyChanged(e);
        }



        private SiteChoices site = SiteChoices.MANILA;
        public SiteChoices Site { get => site; set => SetProperty(ref site, value); }

        private PayrollCode payrollCode = new PayrollCode();
        public PayrollCode PayrollCode { get => payrollCode; set => SetProperty(ref payrollCode, value); }

        private Cutoff cutoff = new Cutoff();
        public Cutoff Cutoff { get => cutoff; set => SetProperty(ref cutoff, value); }

        protected override void OnActivated()
        {
            Messenger.Register<TimesheetListingVm, SelectedSiteChangedMessage>(this, (r, m) => r.Site = m.Value);
            Messenger.Register<TimesheetListingVm, SelectedPayrollCodeChangedMessage>(this, (r, m) => r.PayrollCode = m.Value);
            Messenger.Register<TimesheetListingVm, SelectedCutoffIdChangedMessage>(this, (r, m) => r.Cutoff = new Cutoff(m.Value));
        }
    }
}

