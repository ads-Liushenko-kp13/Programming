using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Success
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartDatePicker.SelectedDate = new DateTime(2000,1,1);
            EndDatePicker.SelectedDate = DateTime.Now;
           // UpdateAuctionTable();
        }

        private void UpdateAuctionTable(string startDateString,string endDateString)
        {
           
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {


                /*SqlDataAdapter Data = new SqlDataAdapter($"SELECT * FROM Auction Where Date> '{startDateString}' AND Date< '{endDateString}'", sqlConn);
                */
                string strQ = "SELECT ID,Name,Date,Time,Address,Description," +
                    "(SELECT top 1 LotID FROM AuctionHistory Where AuctionHistory.AuctionID = Auction.ID" +
                     " order by SalesPrice desc) as MaxPriceLotID," +
                   " (SELECT top 1 BuyerID  FROM AuctionHistory  Where AuctionHistory.AuctionID = Auction.ID" +
                    " order by SalesPrice desc) as MaxPriceBuyerID FROM Auction" +
                    $" Where Date> '{startDateString}' AND Date< '{endDateString}'";
                /*MessageBox.Show(strQ);*/
                DataTable dT = new DataTable();
                SqlDataAdapter Data = new SqlDataAdapter(strQ, sqlConn);
                Data.Fill(dT);
                AuctionGrid.ItemsSource = dT.DefaultView;
                AuctionGrid.SelectedIndex = 0;
               /* if (AuctionGrid.Items != null)
                {
                    object item = AuctionGrid.Items[1]; // = Product X
                    AuctionGrid.SelectedItem = item;
                }*/
               // AuctionGrid.SelectedIndex = 1;

            }

            sqlConn.Close();
            
        }

        private void UpdateBriefLot(int auctionID)
        {
            UpdateMostExpensiveLot(auctionID);
            UpdateMostDifferenceSalesPrice(auctionID);

            

        }

        private void UpdateMostDifferenceSalesPrice(int auctionID)
        {
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                string strQ = "SELECT top 1 LotID,Lot.Name AS 'LotName', SalesPrice - StartPrice as delta" +
                " FROM AuctionHistory JOIN Lot ON AuctionHistory.LotID = Lot.Id" +
                $" Where AuctionHistory.AuctionID = '{auctionID}' " +
                " ORDER BY delta";




                DataTable dT = new DataTable();
                SqlDataAdapter Data = new SqlDataAdapter(strQ, sqlConn);
                Data.Fill(dT);
                TopDifferenceLabel.Content = "Top Diffeence Sale Lot: ";
                if (dT.Rows.Count > 0)
                    TopDifferenceLabel.Content += dT.Rows[0]["LotName"].ToString() + "   Defference Sales Price:" + dT.Rows[0]["Delta"].ToString();
                else
                    TopDifferenceLabel.Content += "-";
            }

            sqlConn.Close();
        }

        private void UpdateMostExpensiveLot(int auctionID)
        {
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                string strQ = "SELECT LotID,Lot.Name AS 'LotName', SalesPrice" +
                " FROM AuctionHistory JOIN Lot ON AuctionHistory.LotID = Lot.Id" +
                $" Where AuctionHistory.AuctionID = '{auctionID}' AND   SalesPrice = (SELECT Max(SalesPrice) FROM AuctionHistory" +
               $" WHERE AuctionID = '{auctionID}') ";



                DataTable dT = new DataTable();
                SqlDataAdapter Data = new SqlDataAdapter(strQ, sqlConn);
                Data.Fill(dT);
                TopPriceLabel.Content = "Top Lot: ";
                if (dT.Rows.Count > 0)
                    TopPriceLabel.Content += dT.Rows[0]["LotName"].ToString()+"   Price: " + dT.Rows[0]["SalesPrice"].ToString();
                else
                    TopPriceLabel.Content += "-";
            }

            sqlConn.Close();
        }

        private void ParticipantButton_Click(object sender, RoutedEventArgs e)
        {
            ParticipantWindow window = new ParticipantWindow();
            window.Show();
        }

        private void AuctionButton_Click(object sender, RoutedEventArgs e)
        {
            AuctionWindow window = new AuctionWindow();
            window.Show();
        }

        private void LotButton_Click(object sender, RoutedEventArgs e)
        {
            LotWindow window = new LotWindow();
            window.Show();
        }

        private void AuctionGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (AuctionGrid.SelectedItem == null && AuctionGrid.Items != null )
            {
                object item = AuctionGrid.Items[0]; // = Product X
                AuctionGrid.SelectedItem = item;
            }
            // MessageBox.Show(AuctionGrid.SelectedItem.ToString()) ;
           
            int auctionID = GetCurrentAuctionID();
            UpdateBuyerTable(auctionID);
            UpdateLotTable(auctionID);
            UpdateBriefLot(auctionID);
            UpdateBriefBuyer(auctionID);
        }


        private void UpdateBriefBuyer(int auctionID)
        {
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {
                string strQ = "SELECT BuyerID,Participant.LastName AS 'BuyerName', SalesPrice" +
                " FROM AuctionHistory JOIN Participant ON AuctionHistory.BuyerID = Participant.Id" +
                $" Where AuctionHistory.AuctionID = '{auctionID}' AND   SalesPrice = (SELECT Max(SalesPrice) FROM AuctionHistory" +
               $" WHERE AuctionID = '{auctionID}') ";



                DataTable dT = new DataTable();
                SqlDataAdapter Data = new SqlDataAdapter(strQ, sqlConn);
                Data.Fill(dT);
                if (dT.Rows.Count > 0)
                    TopBuyerLabel.Content = dT.Rows[0]["BuyerName"].ToString();
                else
                    TopBuyerLabel.Content = "-";
            }

            sqlConn.Close();
        }

        private void UpdateLotTable(int auctionID)
        {
            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {

               /* string strQ = $"Select Lot.Name,Lot.Description,Lot.StartPrice,Participant.LastName AS 'Buyer Name'" +
                    " FROM Lot Join AuctionHistory ON Lot.ID = AuctionHistory.LotID Join " +
                    "Participant ON AuctionHistory.BuyerID = Participant.ID"+
                    $" Where AuctionHistory.AuctionId = '{auctionID}'";*/
                string strQ = $"Select Lot.Name,Lot.Description,Lot.StartPrice,AuctionHistory.SalesPrice,AuctionHistory.SalesPrice-Lot.StartPrice AS 'DeltaPrice',"+
                " Buyer.LastName AS 'Buyer Name',SalesMan.LastName AS 'SalesMan Name'" +
                " FROM Lot Join AuctionHistory ON Lot.ID = AuctionHistory.LotID" +
                " Left Join Participant AS SalesMan ON Lot.SalesmanID = SalesMan.ID" +
                " Left Join Participant AS Buyer ON AuctionHistory.BuyerID = Buyer.ID" +
                $" Where AuctionHistory.AuctionId = '{auctionID}'";
                bool isNotSold = IsNotSoldCheckBox.IsChecked.GetValueOrDefault();
                if (isNotSold)
                    strQ += " AND BuyerId is NULL";

                SqlDataAdapter Data = new SqlDataAdapter(strQ, sqlConn);
                DataTable dT = new DataTable();

                Data.Fill(dT);
                LotGrid.ItemsSource = dT.DefaultView;

            }

            sqlConn.Close();
        }

        private void UpdateBuyerTable(int auctionID)
        {

            SqlConnection sqlConn = new SqlConnection(App.connectionString);
            sqlConn.Open();

            if (sqlConn.State == System.Data.ConnectionState.Open)
            {

                String strQ = $"Select FirstName, LastName, email, phone FROM Participant "
                + $" WHERE id  in (Select buyerID FROM AuctionHistory WHERE AuctionID='{auctionID}')";
                SqlDataAdapter Data = new SqlDataAdapter(strQ, sqlConn);

                SqlCommand Com = new SqlCommand(strQ, sqlConn);
                DataTable dT = new DataTable();

                Data.Fill(dT);
                BuyerGrid.ItemsSource = dT.DefaultView;

            }

            sqlConn.Close();
        }
        private void StartDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime startDate = StartDatePicker.DisplayDate;
            string startDateAuctionString = startDate.ToString("MM-dd-yyyy");
            DateTime endDate = EndDatePicker.DisplayDate;
            string endDateAuctionString = endDate.ToString("MM-dd-yyyy");
            UpdateAuctionTable(startDateAuctionString, endDateAuctionString);

        }

        private void IsNotSoldCheckBox_Click(object sender, RoutedEventArgs e)
        {
            int auctionID = GetCurrentAuctionID();
            UpdateLotTable(auctionID);
        }

        private int GetCurrentAuctionID()
        {
            string auctionIDString = (AuctionGrid.SelectedItem as DataRowView)[0].ToString();
            return Convert.ToInt32(auctionIDString);
        }
    }
}
