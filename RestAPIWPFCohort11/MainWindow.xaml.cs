using Newtonsoft.Json;
using RestAPIWPFCohort11.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace RestAPIWPFCohort11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    /*
     * REST API works through HTTP connection. So, we need to Create an http client in our application
     */
    
    public partial class MainWindow : Window
    {
        HttpClient httpClient = new HttpClient(); // THe rest API always communicate over the http connection
        // mechanism
        
        public MainWindow()
        {
            /*
             * Configure our http client for proper communication
             * 
             * step 01: setup the base address of the RestAPI
             */

            httpClient.BaseAddress = new Uri("https://localhost:7002/api/Students/");
            // step 02: We need to clear default packet header informaiton
            httpClient.DefaultRequestHeaders.Accept.Clear();
            // step 03. Configure the RestAPI packet header
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json") 
                // the reason to add new heard is that the data communication going to take place in our application
                // is in json format
                );
            InitializeComponent();
        }

        private async void Insert_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student(); // As we are going to add the student in the database, we nee
                                             // d to create the instance of the Student class

            student.Id = int.Parse(textBoxID.Text);
            student.FirstName = textBoxFirstName.Text;
            student.LastName = textBoxLastName.Text;
            student.email = textBoxEmail.Text;
            // as the insertion method is configured as Post method, we need to create a json post method over here

            var response = await httpClient.PostAsJsonAsync("AddStudent", student); // the first parameter: the API name, 2nd parameter: the value
            // the previous line will perform the data communication from the client machine to the remote machine
            // await method always put a specific time limit for a request. This requires the method to be async
            // so that the program can continue its execution without being hault for the current execution

            //var response = await httpClient.GetStringAsync("AddStudent");
            // we need to use var over here as we cannot consider that the response we are getting we have the 
            // say Response class structure. We need to Deserialize the reponse Json to Response class to get the 
            // values from the response Message

            Response res = JsonConvert.DeserializeObject<Response>(response.ToString());
            ResponseLabel.Content = res.statusCode + " " + res.statusMessage; 
        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            var response = await httpClient.GetStringAsync("GetStudentByID/"+int.Parse(textBoxID.Text));
            Response response_JSON = JsonConvert.DeserializeObject<Response>(response);

            ResponseLabel.Content = response_JSON.statusCode + " " + response_JSON.statusMessage;
            
            textBoxFirstName.Text = response_JSON.student.FirstName;
            textBoxLastName.Text = response_JSON.student.LastName;
            textBoxEmail.Text = response_JSON.student.email;
        }

        private async void Select_Click(object sender, RoutedEventArgs e)
        {
            var response = await httpClient.GetStringAsync("GetAllStudents");
            Response response_JSON = JsonConvert.DeserializeObject<Response>(response);

            ResponseLabel.Content = response_JSON.statusCode + " " + response_JSON.statusMessage;

            dataGrid.ItemsSource = response_JSON.students;
            DataContext = this;

        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();

            student.Id = int.Parse(textBoxID.Text);
            student.FirstName = textBoxFirstName.Text;
            student.LastName = textBoxLastName.Text;
            student.email = textBoxEmail.Text;

            var response = await httpClient.PutAsJsonAsync("UpdateStudent", student);

            ResponseLabel.Content = response.ToString();
            //Response res_JSON = JsonConvert.DeserializeObject<Response>(response);

        }

        private async void Delete_Info_Click(object sender, RoutedEventArgs e)
        {
            var response = await httpClient.DeleteAsync("DeleteStudent/" + int.Parse(textBoxID.Text));
            ResponseLabel.Content = response.ToString();
            //Response resJson = JsonConvert.DeserializeObject<Response>(response.ToString());
        }

        // for communicating with rest API, we need to establish an asynchronous communication with the
        // backend server.
    }
}
