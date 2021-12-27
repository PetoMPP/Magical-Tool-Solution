using MTSLibrary;
using MTSLibrary.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magical_Tool_Solution.ToolStockCalculations
{
    public partial class CalculationProgress : Form
    {
        private readonly Form caller;
        private readonly List<CompModel> calculatedComps = new();
        private readonly List<int> dummyResults = new();
        private readonly Task calculationTask;
        private static CancellationTokenSource tokenSource = new();
        private readonly CancellationToken ct = tokenSource.Token;
        public CalculationProgress(string mode, List<CompModel> comps, Form callingForm)
        {
            tokenSource = new CancellationTokenSource();
            ct = tokenSource.Token;
            Visible = true;
            caller = callingForm;
            caller.Visible = false;
            InitializeComponent();
            AdjustUI(mode);
            //Calculate(mode, comps);
            if (comps.Count > 0)
            {
                calculationTask = CalculateCompsAsync(comps, mode);
            }
            else
            {
                calculationTask = DummyFunctionAsync(ct);
            }
        }

        private async Task DummyFunctionAsync(CancellationToken ct)
        {
            List<int> output = new();
            int itemValue = 0;
            List<int> data = GenerateDummyData();
            ClearOutputWindow();
            ConfigureProgressBar(data);
            foreach (int item in data)
            {
                AdvanceProgressBar(item);
                calculationOutputBox.Text += $"Calculating: {item}...{Environment.NewLine}";
                try
                {
                    itemValue = await Task.Run(() => DummyOperation(item, ct), ct);
                }
                catch (OperationCanceledException)
                {
                    calculationOutputBox.Text += $"Przerwano operację.{Environment.NewLine}";
                    return;
                }
                calculationOutputBox.Text += $"Calculated {item} as {itemValue} {Environment.NewLine}";
                dummyResults.Add(itemValue);
            }
            closeButton.Enabled = true;
            showResultsButton.Enabled = true;
            cancelButton.Enabled = false;
        }

        private void ClearOutputWindow()
        {
            calculationOutputBox.Text = "";
        }

        private void AdvanceProgressBar(int item)
        {
            progressBar.PerformStep();
            double percProgress = (double)progressBar.Value / progressBar.Maximum * 100;
            percProgress = Math.Round(percProgress, 2);
            progressLabel.Text = $"{item}   {percProgress}% {progressBar.Value}/{progressBar.Maximum}";
        }

        private void ConfigureProgressBar<T>(List<T> data)
        {
            progressBar.Maximum = data.Count;
            double percProgress = 0;
            int currItem = 0;
            int allItems = progressBar.Maximum;
            progressLabel.Text = $"<item>   {percProgress}% {currItem}/{allItems}";
        }

        private static List<int> GenerateDummyData()
        {
            List<int> data = new();
            for (int i = 10; i < 16; i++)
            {
                data.Add(i);
            }
            return data;
        }
        private int DummyOperation(int num, CancellationToken ct)
        {
            if (ct.IsCancellationRequested)
            {
                try
                {
                    ct.ThrowIfCancellationRequested();
                }
                catch (Exception)
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        if (calculationTask.IsCanceled)
                        {
                            calculationTask.Dispose();
                            break;
                        }
                        Thread.Sleep(10);
                    }
                }
            }
            Thread.Sleep(1500);
            Console.WriteLine("Debug");
            if (ct.IsCancellationRequested)
            {
                try
                {
                    ct.ThrowIfCancellationRequested();
                }
                catch (Exception)
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        if (calculationTask.IsCanceled)
                        {
                            calculationTask.Dispose();
                            break;
                        }
                        Thread.Sleep(10);
                    }
                }
            }
            return num + 50;
        }

        private async Task<List<CompModel>> CalculateCompsAsync(List<CompModel> comps, string mode)
        {
            List<CompModel> output = new();
            progressBar.Maximum = comps.Count;
            int percProgress = 0;
            int currItem = 0;
            int allItems = progressBar.Maximum;
            progressLabel.Text = $"{percProgress}% {currItem}/{allItems}";
            foreach (CompModel comp in comps)
            {
                output.Add(await Task.Run(() => CalculateSingleComp(mode, comp)));
                progressBar.PerformStep();
            }
            return output;
        }

        private CompModel CalculateSingleComp(string mode, CompModel comp)
        {
            CompModel output = new();
            if (mode == "missing")
            {
                output = CalculationLogic.CalculateMissingStock(comp);
            }
            if (mode == "minimal")
            {
                output = CalculationLogic.CalculateMinimalStock(comp);
            }
            return output;
        }

        private void Calculate(string mode, List<CompModel> comps)
        {
            //TODO - progress bar setup
            if (mode == "missing")
            {
                foreach (CompModel comp in comps)
                {
                    CalculationLogic.CalculateMissingStock(comp);
                    //TODO - progress bar step
                }
            }
            if (mode == "minimal")
            {
                foreach (CompModel comp in comps)
                {
                    CalculationLogic.CalculateMinimalStock(comp);
                    //TODO - progress bar step
                }
            }
            //TODO - pass the results to the results screen
            //TODO - close this form
        }
        private void AdjustUI(string mode)
        {
            if (mode == "missing")
            {
                calculatingNameLabel.Text = "Obliczanie brakujących ilości narzędzi";
                calculatingDescriptionLabel.Text = @"Trwa obliczanie brakujących stanów wybranych komponentów, 
w zależności od ilości wybranych komponentów obliczanie może chwilę zająć.";
            }
            if (mode == "minimal")
            {
                calculatingNameLabel.Text = "Obliczanie minimalnych ilości narzędzi";
                calculatingDescriptionLabel.Text = @"Trwa obliczanie minimalnych stanów wybranych komponentów, 
w zależności od ilości wybranych komponentów obliczanie może chwilę zająć.";
            }
        }

        private void RestoreCaller(object sender, FormClosedEventArgs e)
        {
            caller.Visible = true;
        }

        private void InterruptTask(object sender, FormClosedEventArgs e)
        {
            tokenSource.Cancel();
            calculationTask.Dispose();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = false;
            tokenSource.Cancel();
            ControlBox = true;
            closeButton.Enabled = true;
            FormClosed += RestoreCaller;
            calculationOutputBox.Text += $"Przerwano operację.{Environment.NewLine}";
        }
        private void ShowResultsButton_Click(object sender, EventArgs e)
        {
            _ = new CalculationResults(caller, dummyResults);
            Close();
            Dispose();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
