using System;
using System.Linq;
using System.Windows.Forms;

namespace TNPathsFinder
{
    public partial class MainForm : Form
    {
        private PathsFinderManager _finderManager;

        public MainForm()
        {
            _finderManager = new PathsFinderManager();

            InitializeComponent();
        }

        private async void tsmiLoadTransportRoutesListFromFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdTransportRoutesFileToReadSelectionDialog.ShowDialog() == DialogResult.OK)
                {
                    var inputDataProvider = new InputDataFileReader(ofdTransportRoutesFileToReadSelectionDialog.FileName);

                    await _finderManager.ReadInputData(inputDataProvider);

                    if (!gbTransportRoutes.Enabled)
                        gbTransportRoutes.Enabled = true;

                    cbSourceTransportStops.Items.Clear();
                    cbSourceTransportStops.Items.AddRange(_finderManager.TransportStops.ToArray());
                    if (cbSourceTransportStops.Items.Count != 0)
                        cbSourceTransportStops.SelectedIndex = 0;

                    cbDestinationTransportStops.Items.Clear();
                    cbDestinationTransportStops.Items.AddRange(_finderManager.TransportStops.ToArray());
                    if (cbDestinationTransportStops.Items.Count != 0)
                        cbDestinationTransportStops.SelectedIndex = 0;
                    
                    if (!_finderManager.TransportVehicles.Any())
                    {
                        tbTransportRoutes.Text = "Нет данных";
                        gbMinPathsInTransportNetworkFinding.Enabled = false;

                    }
                    else
                    {
                        tbTransportRoutes.Text = String.Join($"{Environment.NewLine}{Environment.NewLine}", _finderManager.TransportVehicles);
                        gbMinPathsInTransportNetworkFinding.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникло непредвиденное исключение:{Environment.NewLine}{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bFindMinPathsInTransportNetwork_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbSourceTransportStops.SelectedIndex == cbDestinationTransportStops.SelectedIndex)
                {
                    MessageBox.Show("Начальная и конечная остановки не могу совпадать", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var sourceStop = _finderManager.TransportStops[cbSourceTransportStops.SelectedIndex];
                var destinationStop = _finderManager.TransportStops[cbDestinationTransportStops.SelectedIndex];
                var tripStartTime = new TimeSpan(dtpDepartureTime.Value.TimeOfDay.Hours, dtpDepartureTime.Value.TimeOfDay.Minutes, 0);

                await _finderManager.FinderEngine.FindMinPaths(sourceStop, destinationStop, tripStartTime);

                tbMinTotalCostPaths.Text = _finderManager.FinderEngine.MinCostPaths.Any() ? 
                    String.Join($"{Environment.NewLine}{Environment.NewLine}", _finderManager.FinderEngine.MinCostPaths) : "Нет данных";
                tbMinTotalTimePaths.Text = _finderManager.FinderEngine.MinTimePaths.Any() ?
                    String.Join($"{Environment.NewLine}{Environment.NewLine}", _finderManager.FinderEngine.MinTimePaths) : "Нет данных";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникло непредвиденное исключение:{Environment.NewLine}{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}