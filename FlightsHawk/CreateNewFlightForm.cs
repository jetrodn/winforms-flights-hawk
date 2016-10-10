using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FlightsHawk
{
    public class CreateNewFlightForm : Form
    {
        //
        // Основные используемые компоненты формы
        //
        private Label labelID;
        private Label labelAirline;
        private Label labelStatus;
        private Label labelFrom;
        private Label labelTo;
        private Label labelDepartureTime;
        private Label labelLandingTime;
        private Label labelAircraft;
        private Label labelFlightNumber;
        private Label labelFreeSeats;
        private TextBox textStatus;
        private TextBox textFrom;
        private TextBox textTo;
        private TextBox textDepartureTime;
        private TextBox textLandingTime;
        private TextBox textID;
        private TextBox textAircraft;
        private TextBox textFlightNumber;
        private ComboBox comboBoxAirLine;
        private NumericUpDown numericUpDownFreeSeats;

        private Button buttonCreateNewFlight;

        private readonly SqlConnection conection =
            new SqlConnection("data source = THINKPAD-W540; database = Flights; Integrated Security = SSPI;");

        private readonly SqlCommand command = new SqlCommand();
        private SqlDataReader dataReader;


        public CreateNewFlightForm()
        {
            InitializeComponent();

            conection.Open();
            command.CommandText = "SELECT TOP 1 id FROM FLIGHTS ORDER BY id DESC";
            command.Connection = conection; //при инициализации формы производим коннект к БД
            dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    var temp = int.Parse(dataReader[0].ToString());
                    temp++;

                    textID.Text =(temp.ToString());
                    textID.Enabled = false;
                }
            }

            textDepartureTime.Text = "10.10.2016 00:00:00";
            textLandingTime.Text = "10.10.2016 00:00:00";


            conection.Close();
        }

        private void InitializeComponent()
        {
            labelAirline = new Label();
            comboBoxAirLine = new ComboBox();
            labelFreeSeats = new Label();
            numericUpDownFreeSeats = new NumericUpDown();
            textStatus = new TextBox();
            labelStatus = new Label();
            textFrom = new TextBox();
            labelFrom = new Label();
            textTo = new TextBox();
            labelTo = new Label();
            textDepartureTime = new TextBox();
            labelDepartureTime = new Label();
            textLandingTime = new TextBox();
            labelLandingTime = new Label();
            textID = new TextBox();
            labelID = new Label();
            textAircraft = new TextBox();
            labelAircraft = new Label();
            textFlightNumber = new TextBox();
            labelFlightNumber = new Label();
            buttonCreateNewFlight = new Button();
            ((ISupportInitialize)(numericUpDownFreeSeats)).BeginInit();
            this.SuspendLayout();
            //
            // labelAirline
            //
            labelAirline.AutoSize = true;
            labelAirline.Location = new Point(73, 561);
            labelAirline.Name = "labelAirline";
            labelAirline.Size = new Size(72, 25);
            labelAirline.TabIndex = 59;
            labelAirline.Text = "Airline";
            //
            // comboBoxAirLine
            //
            comboBoxAirLine.FormattingEnabled = true;
            comboBoxAirLine.Items.AddRange(new object[] {
                "United Airlines",
                "Turkish Airlines",
                "AirMoldova",
                "FeedEx"});
            comboBoxAirLine.Location = new Point(243, 557);
            comboBoxAirLine.Name = "comboBoxAirLine";
            comboBoxAirLine.Size = new Size(262, 33);
            comboBoxAirLine.TabIndex = 58;
            //
            // labelFreeSeats
            //
            labelFreeSeats.AutoSize = true;
            labelFreeSeats.Location = new Point(73, 357);
            labelFreeSeats.Name = "labelFreeSeats";
            labelFreeSeats.Size = new Size(114, 25);
            labelFreeSeats.TabIndex = 57;
            labelFreeSeats.Text = "Free seats";
            //
            // numericUpDownFreeSeats
            //
            numericUpDownFreeSeats.Location = new Point(243, 358);
            numericUpDownFreeSeats.Name = "numericUpDownFreeSeats";
            numericUpDownFreeSeats.Size = new Size(120, 31);
            numericUpDownFreeSeats.TabIndex = 56;
            //
            // textStatus
            //
            textStatus.Location = new Point(243, 625);
            textStatus.Margin = new Padding(3, 4, 3, 4);
            textStatus.Name = "textStatus";
            textStatus.Size = new Size(262, 31);
            textStatus.TabIndex = 55;
            //
            // labelStatus
            //
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(73, 631);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(73, 25);
            labelStatus.TabIndex = 54;
            labelStatus.Text = "Status";
            //
            // textFrom
            //
            textFrom.Location = new Point(243, 426);
            textFrom.Margin = new Padding(3, 4, 3, 4);
            textFrom.Name = "textFrom";
            textFrom.Size = new Size(262, 31);
            textFrom.TabIndex = 53;
            //
            // labelFrom
            //
            labelFrom.AutoSize = true;
            labelFrom.Location = new Point(73, 432);
            labelFrom.Name = "labelFrom";
            labelFrom.Size = new Size(61, 25);
            labelFrom.TabIndex = 52;
            labelFrom.Text = "From";
            //
            // textTo
            //
            textTo.Location = new Point(243, 485);
            textTo.Margin = new Padding(3, 4, 3, 4);
            textTo.Name = "textTo";
            textTo.Size = new Size(262, 31);
            textTo.TabIndex = 51;
            //
            // labelTo
            //
            labelTo.AutoSize = true;
            labelTo.Location = new Point(73, 485);
            labelTo.Name = "labelTo";
            labelTo.Size = new Size(37, 25);
            labelTo.TabIndex = 50;
            labelTo.Text = "To";
            //
            // textDepartureTime
            //
            textDepartureTime.Location = new Point(243, 239);
            textDepartureTime.Margin = new Padding(3, 4, 3, 4);
            textDepartureTime.Name = "textDepartureTime";
            textDepartureTime.Size = new Size(262, 31);
            textDepartureTime.TabIndex = 49;
            //
            // labelDepartureTime
            //
            labelDepartureTime.AutoSize = true;
            labelDepartureTime.Location = new Point(73, 245);
            labelDepartureTime.Name = "labelDepartureTime";
            labelDepartureTime.Size = new Size(153, 25);
            labelDepartureTime.TabIndex = 48;
            labelDepartureTime.Text = "Departure time";
            //
            // textLandingTime
            //
            textLandingTime.Location = new Point(243, 298);
            textLandingTime.Margin = new Padding(3, 4, 3, 4);
            textLandingTime.Name = "textLandingTime";
            textLandingTime.Size = new Size(262, 31);
            textLandingTime.TabIndex = 47;
            //
            // labelLandingTime
            //
            labelLandingTime.AutoSize = true;
            labelLandingTime.Location = new Point(73, 298);
            labelLandingTime.Name = "labelLandingTime";
            labelLandingTime.Size = new Size(135, 25);
            labelLandingTime.TabIndex = 46;
            labelLandingTime.Text = "Landing time";
            //
            // textID
            //
            textID.Location = new Point(243, 45);
            textID.Margin = new Padding(3, 4, 3, 4);
            textID.Name = "textID";
            textID.Size = new Size(262, 31);
            textID.TabIndex = 45;
            //
            // labelID
            //
            labelID.AutoSize = true;
            labelID.Location = new Point(73, 51);
            labelID.Name = "labelID";
            labelID.Size = new Size(32, 25);
            labelID.TabIndex = 44;
            labelID.Text = "ID";
            //
            // textAircraft
            //
            textAircraft.Location = new Point(243, 163);
            textAircraft.Margin = new Padding(3, 4, 3, 4);
            textAircraft.Name = "textAircraft";
            textAircraft.Size = new Size(262, 31);
            textAircraft.TabIndex = 43;
            //
            // labelAircraft
            //
            labelAircraft.AutoSize = true;
            labelAircraft.Location = new Point(73, 163);
            labelAircraft.Name = "labelAircraft";
            labelAircraft.Size = new Size(80, 25);
            labelAircraft.TabIndex = 42;
            labelAircraft.Text = "Aircraft";
            //
            // textFlightNumber
            //
            textFlightNumber.Location = new Point(243, 104);
            textFlightNumber.Margin = new Padding(3, 4, 3, 4);
            textFlightNumber.Name = "textFlightNumber";
            textFlightNumber.Size = new Size(262, 31);
            textFlightNumber.TabIndex = 41;
            //
            // labelFlightNumber
            //
            labelFlightNumber.AutoSize = true;
            labelFlightNumber.Location = new Point(73, 104);
            labelFlightNumber.Name = "labelFlightNumber";
            labelFlightNumber.Size = new Size(143, 25);
            labelFlightNumber.TabIndex = 40;
            labelFlightNumber.Text = "Flight number";
            //
            // buttonCreateNewFlight
            //
            buttonCreateNewFlight.Location = new Point(78, 758);
            buttonCreateNewFlight.Name = "buttonCreateNewFlight";
            buttonCreateNewFlight.Size = new Size(427, 52);
            buttonCreateNewFlight.TabIndex = 60;
            buttonCreateNewFlight.Text = "Create new Fligth";
            buttonCreateNewFlight.UseVisualStyleBackColor = true;
//            buttonCreateNewFlight.Click += this.buttonNewFlight_Click;
            //
            // NewFlightForm
            //
            this.AutoScaleDimensions = new SizeF(12F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(556, 901);
            this.Controls.Add(buttonCreateNewFlight);
            this.Controls.Add(labelAirline);
            this.Controls.Add(comboBoxAirLine);
            this.Controls.Add(labelFreeSeats);
            this.Controls.Add(numericUpDownFreeSeats);
            this.Controls.Add(textStatus);
            this.Controls.Add(labelStatus);
            this.Controls.Add(textFrom);
            this.Controls.Add(labelFrom);
            this.Controls.Add(textTo);
            this.Controls.Add(labelTo);
            this.Controls.Add(textDepartureTime);
            this.Controls.Add(labelDepartureTime);
            this.Controls.Add(textLandingTime);
            this.Controls.Add(labelLandingTime);
            this.Controls.Add(textID);
            this.Controls.Add(labelID);
            this.Controls.Add(textAircraft);
            this.Controls.Add(labelAircraft);
            this.Controls.Add(textFlightNumber);
            this.Controls.Add(labelFlightNumber);
            this.Name = "NewFlightForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "NewFlightForm";
            ((ISupportInitialize)(numericUpDownFreeSeats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}