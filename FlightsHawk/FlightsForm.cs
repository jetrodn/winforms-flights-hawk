using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FlightsHawk
{
    public class FlightsForm : Form
    {
        //
        // Основные используемые компоненты формы
        //
        private Label labelFlightNumber;
        private Label labelAircraft;
        private Label labelID;
        private Label labelLandingTime;
        private Label labelDepartureTime;
        private Label labelFrom;
        private Label labelTo;
        private Label labelStatus;
        private Label labelAirline;
        private Label labelFreeSeats;
        private Label labelTooltip;
        private TextBox textFlightNumber;
        private TextBox textAircraft;
        private TextBox textID;
        private TextBox textDepartureTime;
        private TextBox textLandingTime;
        private TextBox textFrom;
        private TextBox textTo;
        private TextBox textStatus;
        private NumericUpDown numericUpDownFreeSeats;
        private ComboBox comboBoxAirLine;
        private ListBox listBox;
        private Button createButton;
        private Button updateButton;
        private Button deleteButton;

        //
        // Инициализация SQL подключения к Базе Данных
        //
        private readonly SqlConnection conection =
            new SqlConnection("data source = THINKPAD-W540; database = Flights; Integrated Security = SSPI;");

        private readonly SqlCommand command = new SqlCommand();
        private SqlDataReader dataReader;

        //
        // Конструктор по умолчанию
        //
        public FlightsForm()
        {
            InitializeComponents();
        }

        //
        // События, после загрузки всех компонентов формы
        //
        private void FlightsForm_Load(object sender, EventArgs e)
        {
            //производим коннект к БД
            command.Connection = conection;
            LoadList();
        }

        //
        // Инициализация всех компонентов формы
        //
        private void InitializeComponents()
        {
            labelFlightNumber = new Label();
            textFlightNumber = new TextBox();
            labelAircraft = new Label();
            textAircraft = new TextBox();
            createButton = new Button();
            updateButton = new Button();
            deleteButton = new Button();
            listBox = new ListBox();
            labelID = new Label();
            textID = new TextBox();
            textDepartureTime = new TextBox();
            labelDepartureTime = new Label();
            textLandingTime = new TextBox();
            labelLandingTime = new Label();
            textFrom = new TextBox();
            labelFrom = new Label();
            textTo = new TextBox();
            labelTo = new Label();
            textStatus = new TextBox();
            labelStatus = new Label();
            numericUpDownFreeSeats = new NumericUpDown();
            labelFreeSeats = new Label();
            comboBoxAirLine = new ComboBox();
            labelAirline = new Label();
            labelTooltip = new Label();

            labelFlightNumber.AutoSize = true;
            labelFlightNumber.Location = new Point(24, 167);
            labelFlightNumber.Name = "labelFlightNumber";
            labelFlightNumber.Size = new Size(145, 26);
            labelFlightNumber.TabIndex = 0;
            labelFlightNumber.Text = "Flight number";

            textFlightNumber.Location = new Point(194, 167);
            textFlightNumber.Margin = new Padding(3, 4, 3, 4);
            textFlightNumber.Name = "textFlightNumber";
            textFlightNumber.Size = new Size(262, 32);
            textFlightNumber.TabIndex = 1;

            labelAircraft.AutoSize = true;
            labelAircraft.Location = new Point(24, 226);
            labelAircraft.Name = "labelAircraft";
            labelAircraft.Size = new Size(81, 26);
            labelAircraft.TabIndex = 2;
            labelAircraft.Text = "Aircraft";

            textAircraft.Location = new Point(194, 226);
            textAircraft.Margin = new Padding(3, 4, 3, 4);
            textAircraft.Name = "textAircraft";
            textAircraft.Size = new Size(262, 32);
            textAircraft.TabIndex = 3;

            createButton.Location = new Point(814, 916);
            createButton.Margin = new Padding(3, 4, 3, 4);
            createButton.Name = "createButton";
            createButton.Size = new Size(325, 57);
            createButton.TabIndex = 4;
            createButton.Text = "New Flight";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;

            updateButton.Location = new Point(1189, 916);
            updateButton.Margin = new Padding(3, 4, 3, 4);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(325, 57);
            updateButton.TabIndex = 5;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;

            deleteButton.Location = new Point(1565, 916);
            deleteButton.Margin = new Padding(3, 4, 3, 4);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(325, 57);
            deleteButton.TabIndex = 6;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;

            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 26;
            listBox.Location = new Point(221, 354);
            listBox.Margin = new Padding(3, 4, 3, 4);
            listBox.Name = "listBox";
            listBox.Size = new Size(2281, 342);
            listBox.TabIndex = 11;
            listBox.SelectedIndexChanged += listBox_SelectedIndexChanged;

            labelID.AutoSize = true;
            labelID.Location = new Point(24, 114);
            labelID.Name = "labelID";
            labelID.Size = new Size(34, 26);
            labelID.TabIndex = 13;
            labelID.Text = "ID";

            textID.Location = new Point(194, 108);
            textID.Margin = new Padding(3, 4, 3, 4);
            textID.Name = "textID";
            textID.Size = new Size(262, 32);
            textID.TabIndex = 14;

            textDepartureTime.Location = new Point(993, 102);
            textDepartureTime.Margin = new Padding(3, 4, 3, 4);
            textDepartureTime.Name = "textDepartureTime";
            textDepartureTime.Size = new Size(262, 32);
            textDepartureTime.TabIndex = 22;

            labelDepartureTime.AutoSize = true;
            labelDepartureTime.Location = new Point(823, 108);
            labelDepartureTime.Name = "labelDepartureTime";
            labelDepartureTime.Size = new Size(156, 26);
            labelDepartureTime.TabIndex = 21;
            labelDepartureTime.Text = "Departure time";

            textLandingTime.Location = new Point(993, 161);
            textLandingTime.Margin = new Padding(3, 4, 3, 4);
            textLandingTime.Name = "textLandingTime";
            textLandingTime.Size = new Size(262, 32);
            textLandingTime.TabIndex = 18;

            labelLandingTime.AutoSize = true;
            labelLandingTime.Location = new Point(823, 161);
            labelLandingTime.Name = "labelLandingTime";
            labelLandingTime.Size = new Size(137, 26);
            labelLandingTime.TabIndex = 17;
            labelLandingTime.Text = "Landing time";

            textFrom.Location = new Point(1703, 102);
            textFrom.Margin = new Padding(3, 4, 3, 4);
            textFrom.Name = "textFrom";
            textFrom.Size = new Size(262, 32);
            textFrom.TabIndex = 28;

            labelFrom.AutoSize = true;
            labelFrom.Location = new Point(1533, 108);
            labelFrom.Name = "labelFrom";
            labelFrom.Size = new Size(63, 26);
            labelFrom.TabIndex = 27;
            labelFrom.Text = "From";

            textTo.Location = new Point(1703, 161);
            textTo.Margin = new Padding(3, 4, 3, 4);
            textTo.Name = "textTo";
            textTo.Size = new Size(262, 32);
            textTo.TabIndex = 24;

            labelTo.AutoSize = true;
            labelTo.Location = new Point(1533, 161);
            labelTo.Name = "labelTo";
            labelTo.Size = new Size(36, 26);
            labelTo.TabIndex = 23;
            labelTo.Text = "To";

            textStatus.Location = new Point(2405, 176);
            textStatus.Margin = new Padding(3, 4, 3, 4);
            textStatus.Name = "textStatus";
            textStatus.Size = new Size(262, 32);
            textStatus.TabIndex = 34;

            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(2235, 182);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(74, 26);
            labelStatus.TabIndex = 33;
            labelStatus.Text = "Status";

            numericUpDownFreeSeats.Location = new Point(993, 221);
            numericUpDownFreeSeats.Name = "numericUpDownFreeSeats";
            numericUpDownFreeSeats.Size = new Size(120, 32);
            numericUpDownFreeSeats.TabIndex = 36;

            labelFreeSeats.AutoSize = true;
            labelFreeSeats.Location = new Point(823, 220);
            labelFreeSeats.Name = "labelFreeSeats";
            labelFreeSeats.Size = new Size(114, 26);
            labelFreeSeats.TabIndex = 37;
            labelFreeSeats.Text = "Free seats";

            comboBoxAirLine.FormattingEnabled = true;
            comboBoxAirLine.Items.AddRange(new object[]
            {
                "United Airlines",
                "Turkish Airlines",
                "AirMoldova",
                "FeedEx"
            });
            comboBoxAirLine.Location = new Point(2405, 108);
            comboBoxAirLine.Name = "comboBoxAirLine";
            comboBoxAirLine.Size = new Size(262, 34);
            comboBoxAirLine.TabIndex = 38;

            labelAirline.AutoSize = true;
            labelAirline.Location = new Point(2235, 112);
            labelAirline.Name = "labelAirline";
            labelAirline.Size = new Size(73, 26);
            labelAirline.TabIndex = 39;
            labelAirline.Text = "Airline";

            labelTooltip.AutoSize = true;
            labelTooltip.ForeColor = Color.SlateGray;
            labelTooltip.Location = new Point(785, 836);
            labelTooltip.Name = "labelTooltip";
            labelTooltip.Size = new Size(1162, 52);
            labelTooltip.TabIndex = 40;
            labelTooltip.Text = "Для создания нового полета воспользуйтесь кнопкой New Flight. \r\n Для того, чтобы о" +
                                "бновить существующую запись, выделите нужную запись выше и измените нужное значе" +
                                "ние.";
            labelTooltip.TextAlign = ContentAlignment.TopCenter;

            //
            // Настройка самого окна
            // Временно приостанавливает логику макета для элемента управления
            //
            SuspendLayout();

            //использование авто-скалирования интерфейса для 200dpi
            AutoScaleDimensions = new SizeF(190F, 190F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(2679, 1074);

            //
            // Добавляем все наши компоненты
            //
            Controls.Add(labelTooltip);
            Controls.Add(labelAirline);
            Controls.Add(comboBoxAirLine);
            Controls.Add(labelFreeSeats);
            Controls.Add(numericUpDownFreeSeats);
            Controls.Add(textStatus);
            Controls.Add(labelStatus);
            Controls.Add(textFrom);
            Controls.Add(labelFrom);
            Controls.Add(textTo);
            Controls.Add(labelTo);
            Controls.Add(textDepartureTime);
            Controls.Add(labelDepartureTime);
            Controls.Add(textLandingTime);
            Controls.Add(labelLandingTime);
            Controls.Add(textID);
            Controls.Add(labelID);
            Controls.Add(listBox);
            Controls.Add(deleteButton);
            Controls.Add(updateButton);
            Controls.Add(createButton);
            Controls.Add(textAircraft);
            Controls.Add(labelAircraft);
            Controls.Add(textFlightNumber);
            Controls.Add(labelFlightNumber);

            //
            // Настройка шрифтов, названия окна и инициалзация формы
            //
            Font = new Font("Microsoft Sans Serif", 8.25F);
            Margin = new Padding(10, 10, 10, 10);
            Name = "FlightsForm";
            Text = "Vladimir Rodin - FlightHawk Application - WinForms";
            WindowState = FormWindowState.Maximized;
            Load += FlightsForm_Load;
            ResumeLayout(false);

            //
            // Вызываем в элементе управления принудительное
            // применение логики макета ко всем его дочерним
            // элементам управления
            //
            PerformLayout();
        }

        //
        // Метод, который вызывается по нажатию кнопки createButton
        //
        private void createButton_Click(object sender, EventArgs e)
        {
            CreateNewFlightForm form = new CreateNewFlightForm();
            form.ShowDialog();
            LoadList();
        }

        //
        // Метод, загружающий все данные из БД
        // Отображает данные в listBox
        //
        private void LoadList()
        {
            listBox.Items.Clear();
            updateButton.Enabled = false;

            conection.Open();
            command.CommandText = "SELECT * FROM FLIGHTS";
            dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    listBox.ColumnWidth = 600;

                    listBox.Items.Add(
                        dataReader[0].ToString().PadRight(10 - dataReader[0].ToString().Length) + "\t"
                        + dataReader[1].ToString().PadRight(20 - dataReader[0].ToString().Length) + "\t"
                        + dataReader[2].ToString().PadRight(20 - dataReader[0].ToString().Length) + "\t"
                        + dataReader[3].ToString().PadRight(20 - dataReader[0].ToString().Length) + "\t\t"
                        + dataReader[4].ToString().PadRight(20 - dataReader[0].ToString().Length) + "\t"
                        + dataReader[5].ToString().PadRight(20 - dataReader[0].ToString().Length) + "\t"
                        + dataReader[6].ToString().PadRight(20 - dataReader[0].ToString().Length) + "\t"
                        + dataReader[7].ToString().PadRight(20 - dataReader[0].ToString().Length) + "\t"
                        + dataReader[8].ToString().PadRight(20 - dataReader[8].ToString().Length) + "\t"
                        + dataReader[9]
                    );
                }
            }
            conection.Close();
        }

        //
        // Метод, очищающий все поля в главной форме
        //
        private void RefreshFields()
        {
            textID.Text = "";
            textFlightNumber.Text = "";
            textAircraft.Text = "";
            textDepartureTime.Text = "";
            textLandingTime.Text = "";
            textStatus.Text = "";
            textFrom.Text = "";
            textTo.Text = "";
            comboBoxAirLine.Text = "";
            numericUpDownFreeSeats.Text = "";
        }

        //
        // Метод, который позволяет произвести удаление данных из БД
        //
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (textID.Text != "")
            {
                conection.Open();
                String createSqlCommand = "DELETE FROM FLIGHTS WHERE id = '" + textID.Text + "'";
                command.CommandText = createSqlCommand;
                command.ExecuteNonQuery();
                conection.Close();

                MessageBox.Show(@"Flight was deleted!", @"Deleting Flight");
                conection.Close();
                RefreshFields();

                LoadList();
            }
        }

        //
        // Метод, отслеживающий изменения в listBox
        //
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listBoxLocal = sender as ListBox;
            updateButton.Enabled = true;

            if (listBoxLocal != null && listBoxLocal.SelectedIndex != -1)
            {
                //берем индекс выбранной строчки
                listBoxLocal.SelectedIndex = listBox.SelectedIndex; // 0 ... !!!!

                //var text = (listBoxLocal.SelectedItem as DataRowView)["flight_number"].ToString();
                //var sourceLine = listBoxLocal.SelectedItem.ToString();
                //MessageBox.Show(
                //    @"ID: " + sourceLine.Substring(0, Math.Max(sourceLine.IndexOf('\t'), 10))
                //    + "Flight number: " + listBoxLocal.SelectedItem.ToString().Substring(30, '\t')); //10 second, 30, 60

                Flight flights = new Flight();
                dataReader = flights.GetAllFlights();

                int countRowIndex = listBoxLocal.SelectedIndex;
                //MessageBox.Show(countRowIndex.ToString());
                int count = 0;

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        //если нужная нам строчка совпадает с индексом, то тогда заполняем наши текстовые поля
                        if (count == countRowIndex)
                        {
                            textID.Text = dataReader[0].ToString();
                            textFlightNumber.Text = dataReader[1].ToString();
                            textAircraft.Text = dataReader[2].ToString();
                            textDepartureTime.Text = dataReader[3].ToString();
                            textLandingTime.Text = dataReader[4].ToString();
                            textStatus.Text = dataReader[5].ToString();
                            textFrom.Text = dataReader[6].ToString();
                            textTo.Text = dataReader[7].ToString();
                            comboBoxAirLine.Text = dataReader[8].ToString();
                            numericUpDownFreeSeats.Text = dataReader[9].ToString();
                        }
                        count++;
                    }
                }
                conection.Close();
            }
        }

        //
        // Метод, позволяющий произвести обновление записи
        //
        private void updateButton_Click(object sender, EventArgs e)
        {
            conection.Open();

            String updateSqlCommand = "UPDATE FLIGHTS SET " +
                                      "id = '" + textID.Text + "', " +
                                      "flight_number = '" + textFlightNumber.Text + "', " +
                                      "aircraft = '" + textAircraft.Text + "', " +
                                      "departure_time = '" + textDepartureTime.Text + "', " +
                                      "landing_time = '" + textLandingTime.Text + "', " +
                                      "status = '" + textStatus.Text + "', " +
                                      "departure = '" + textFrom.Text + "', " +
                                      "destination = '" + textTo.Text + "', " +
                                      "airline = '" + comboBoxAirLine.Text + "', " +
                                      "free_seats = '" + numericUpDownFreeSeats.Text + "' " +
                                      "WHERE ID = '" + textID.Text + "'";


            command.CommandText = updateSqlCommand;
            command.ExecuteNonQuery();
            conection.Close();

            MessageBox.Show(@"Flight was updated!", @"Updating Flight");
            conection.Close();
            RefreshFields();
            LoadList();
        }
    }
}