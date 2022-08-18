using Syncfusion.Maui.Gauges;

namespace TimePicker;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        DateTime currentDateTime = DateTime.Now;
        this.HoursLabel.Text = currentDateTime.ToString("hh");
        this.MinutesLabel.Text = currentDateTime.Minute.ToString();
        pointer.Value = Convert.ToDouble(this.HoursLabel.Text);
        if (currentDateTime.ToString("tt") == "AM")
        {
            this.AMLabel.TextColor = Colors.White;
        }
        else
        {
            this.PMLabel.TextColor = Colors.White;
        }
    }

    private void Hours_Tapped(object sender, EventArgs e)
    {
        this.timerPickerAxis.Maximum = 12;
        this.timerPickerAxis.Interval = 1;
        this.pointer.Value = Convert.ToDouble(this.HoursLabel.Text);
        this.HoursLabel.TextColor = Colors.White;
        this.MinutesLabel.TextColor = Color.FromArgb("#88FFFFFF");
    }

    private void Minutes_Tapped(object sender, EventArgs e)
    {
        this.timerPickerAxis.Maximum = 60;
        this.timerPickerAxis.Interval = 5;
        this.pointer.Value = Convert.ToDouble(this.MinutesLabel.Text);
        this.HoursLabel.TextColor = Color.FromArgb("#88FFFFFF");
        this.MinutesLabel.TextColor = Colors.White;
    }

    private void AM_Tapped(object sender, EventArgs e)
    {
        this.AMLabel.TextColor = Colors.White;
        this.PMLabel.TextColor = Color.FromArgb("#88FFFFFF");
    }

    private void PM_Tapped(object sender, EventArgs e)
    {
        this.AMLabel.TextColor = Color.FromArgb("#88FFFFFF");
        this.PMLabel.TextColor = Colors.White;
    }

    private void pointer_ValueChanging(object sender, ValueChangingEventArgs e)
    {
        double newValue = 0;
        if (e.NewValue != 60)
        {
            newValue = e.NewValue;
        }

        if (this.timerPickerAxis.Maximum == 12)
        {
            this.HoursLabel.Text = newValue.ToString("00");
        }
        else
        {
            this.MinutesLabel.Text = newValue.ToString("00");
        }
    }

    private void pointer_ValueChangeCompleted(object sender, Syncfusion.Maui.Gauges.ValueChangedEventArgs e)
    {
        if (this.timerPickerAxis.Maximum == 12)
        {
            this.timerPickerAxis.Maximum = 60;
            this.timerPickerAxis.Interval = 5;
            this.pointer.Value = Convert.ToDouble(this.MinutesLabel.Text);
            this.HoursLabel.TextColor = Color.FromArgb("#88FFFFFF");
            this.MinutesLabel.TextColor = Colors.White;
        }
    }
}