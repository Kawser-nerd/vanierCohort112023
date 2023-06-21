using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
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
using Npgsql;

namespace sqlVanCohort11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
         * DataBase Connection
         * 
         * The working steps of the database are:
         * 
         * 1. DataBase Connection with Connection String
         * 2. Establish the  Connection
         * -- Open the Connection
         * 3. Generate the SQL Command
         * 4. Execute the Command
         * 5. Close the Connection to Save the Results
         * 
         * 
         */


        //Step 1. Database Connection
        
        // Generate Connection String
        private static string getConnectionString()
        {
            string host = "Host=localhost;"; // don't put any spaces inside the String
            string port = "Port=5432;"; // we need to pass the semicolon to seperate each of the 
            //parameters in the connection string. So, we have to put semicolon after each connection part
            string dbName = "Database=VanierCohort11;";
            string userName = "Username=postgres;";
            string password = "Password=1234;";

            // we are going to pass the values of the string variables we have declared here
            // we need to use Format method to retrieve the values of the variables by
            // passing them in this Method.
            string connectString = string.Format("{0}{1}{2}{3}{4}", host, port, dbName, userName, password);
            return connectString;
        }


        // Step 2: Establish Connection

        // Connection Adapter
        public static NpgsqlConnection con; // this is the connection adapter, helps to connect to a postgresql Database
        // Command Adapter: helps to send/execute any command in the database
        public static NpgsqlCommand cmd;


        private static void establishConnection()
        {
            try
            {
                con = new NpgsqlConnection(getConnectionString()); 
                // we need to pass the connectionString inside the NpgsqlConnection adapter
                // to do so, our connection string will be returned by the getConnectionString()
                // method. So, we pass the getConnectionString() method inside the adapter Constructor
                
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                System.Windows.Application.Current.Shutdown();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InsertSQL_Click(object sender, RoutedEventArgs e)
        {
            // Insert Operation to Database
            // First step is to call the connection establishment method
            establishConnection();
            try
            {
                // Second step is to make the connection open
                con.Open();

                // Third step is to generate sql Query String
                string Query = "insert into students values(@id, @FirstName, @LastName, @email)";
                // don't break the datatable column sequence 

                // Creating the command adapter
                cmd = new NpgsqlCommand(Query, con); // in the command adapter, we need to pass the query
                                                     // as well as the connection adapter
                cmd.Parameters.AddWithValue("@id", int.Parse(InsertID.Text)); //InsertID.Text is in String format..
                                                                              //we need to convert is to Integer
                                                                              // as our datacolumn is integer
                                                                              // We always need to convert our input to the
                                                                              // related column datatype
                cmd.Parameters.AddWithValue("@FirstName", InsertFName.Text);
                cmd.Parameters.AddWithValue("@LastName", InsertLName.Text);
                cmd.Parameters.AddWithValue("@email", insertEmail.Text);

                // Execute our Query
                cmd.ExecuteNonQuery(); // To execute the Query without any checking
                MessageBox.Show("Successfully inserted in the Database");
                con.Close();
            }
            catch(NpgsqlException ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void SelectSQL_Click(object sender, RoutedEventArgs e)
        {
            // Establish the Connection
            establishConnection();
            // Open the Connection
            try
            {
                con.Open();
                // Generate the SQL Query
                string Query = "select * from students";
                // command adapter
                cmd = new NpgsqlCommand(Query, con);

                /*
                 * as we are going to view our data table entries in GridView, we need
                 * a dataapater to pull the data entries and view them in the GridView
                 In the data adapter, you need to pass the command adpater you have created
                for your program. here, cmd is our commandadapter
                 
                After having the dataadpater, we need to create a datatable instance and
                add all our pulled record to that table, We need these table to 
                information our datagridview to know what columns and rows its going to view
                as table
                 */

                NpgsqlDataAdapter npgsqlDataAdapter = new NpgsqlDataAdapter(cmd); 
                DataTable dt = new DataTable();
                npgsqlDataAdapter.Fill(dt); // this line helps to retrive the table
                // we have created using the Data adapter, pass the structure to our
                // regular datatable and get all the values to that table

                // The following line will help us to add the values to the dataGrid view
                dataGrid.ItemsSource = dt.AsDataView();

                //This will perform the dynamic binding, It will update the grid with the
                // passed data table information
                DataContext = npgsqlDataAdapter;
                con.Close();

            }
            catch(NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void UpdateSQL_Click(object sender, RoutedEventArgs e)
        {
            establishConnection();
            try
            {
                con.Open(); // open the connection with Backend database
               // string Query = "Update table students set firstname='"+ InsertFName.Text +"', " +
               //     "lastname='"+InsertLName.Text+"', " +
               //     "email='"+insertEmail.Text+"' " +
                //    "where id='"+int.Parse(InsertID.Text)+"'";
                string Query = "Update students set firstname=@FirstName, " +
                    "lastname=@LastName, " +
                    "email=@Email where id=@ID";
                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@FirstName", InsertFName.Text);
                cmd.Parameters.AddWithValue("@LastName", InsertLName.Text);
                cmd.Parameters.AddWithValue("@Email", insertEmail.Text);
                cmd.Parameters.AddWithValue("@ID", int.Parse(InsertID.Text));

                cmd.ExecuteNonQuery();
                con.Close();
            }catch(NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteSQL_Click(object sender, RoutedEventArgs e)
        {
            establishConnection();
            try
            {
                con.Open(); // open the connection with Backend database
                            // string Query = "Update table students set firstname='"+ InsertFName.Text +"', " +
                            //     "lastname='"+InsertLName.Text+"', " +
                            //     "email='"+insertEmail.Text+"' " +
                            //    "where id='"+int.Parse(InsertID.Text)+"'";
                string Query = "Delete from students where id=@ID";
                cmd = new NpgsqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@ID", int.Parse(InsertID.Text));

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task SearchBtn_ClickAsync(object sender, RoutedEventArgs e)
        {
            establishConnection();
            // Establish the Connection
            establishConnection();
            // Open the Connection
            try
            {
                con.Open();
                // Generate the SQL Query
                string Query = "select * from students where id=@ID";
                // command adapter
                cmd = new NpgsqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ID", int.Parse(studentID.Text));

                /*
                 * in this program, we are going to add a reader to read one entry from the 
                 * database
                 */
                var reader = await cmd.ExecuteReaderAsync();

                InsertID.Text = reader.GetOrdinal("ID").ToString();
                InsertFName.Text = reader.GetOrdinal("firstname").ToString();
                InsertLName.Text = reader.GetOrdinal("lastname").ToString();
                insertEmail.Text = reader.GetOrdinal("email").ToString();

                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
