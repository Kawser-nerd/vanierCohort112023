using Npgsql;
using System.Data;

namespace RestAPICohort.Models
{
    public class Application
    {
        // This class is going to hold all the APIs we are going to add in our restAPI for Student table
        public Response GetAllStudents(NpgsqlConnection con)
        {
            string Query = "Select * from students";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            // the application is going to get the information from the database as a response message dump
            Response response = new Response(); // instance of response class
            List<Student> listofStudents = new List<Student>();
            // the following code will retrieve data from the remote server. This is directly going to execute 
            // on remote side/server

            if (dt.Rows.Count > 0) // just to check whether the application can retrieve any values from the dataTable
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    // the information we are going to retrieve from the remote student table, are going to follow
                    // the student class structure. So, we need to create an instance of the Student class

                    Student student = new Student();
                    student.Id = (int)dt.Rows[i]["id"]; // try to put same type of column name when you are retrieving json datadump
                    student.FirstName = (string) dt.Rows[i]["FirstName"];
                    student.LastName = (string)dt.Rows[i]["LastName"];
                    student.email = (string)dt.Rows[i]["email"];

                    listofStudents.Add(student);
                
                }
            }

            // now, in the folloing block, we are going to create the response message from our client side

            if(listofStudents.Count>0) // this means our database has some entries and those are retrieved properly
            {
                response.statusCode = 200; // 200 statuscode represents successfull query
                response.statusMessage = "Data retrievable is successfull";
                response.students = listofStudents;
            }
            else
            {
                response.statusCode = 100;  // 100 statuscode represents unsuccessful query/ no data presents
                response.statusMessage = "No data retrieved";
                response.students = null; // null value is passing to show no values are retrieve from the remote server
            }
            return response;
        }

        public Response GetStudentbyID(NpgsqlConnection con, int id)
        {
            Response response = new Response();

            string Query = "select * from students where id='"+ id +"'";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(Query, con);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // in this code section, we can retrieve the server data entry as well as the response message itself
                Student student = new Student();
                student.Id = (int)dt.Rows[0]["id"];
                student.FirstName = (string)dt.Rows[0]["FirstName"];
                student.LastName = (string)dt.Rows[0]["LastName"];
                student.email = (string)dt.Rows[0]["email"];

                response.statusCode = 200; // the query is successful
                response.statusMessage = "The data retrieved successfully";
                response.student = student;

            }
            else
            {
                response.statusCode = 100; // the query is unsuccessful
                response.statusMessage = "No data retrieved";
                response.student = null;
            }
            return response;
        }

        public Response AddStudent(NpgsqlConnection con, Student student)
        {
            Response response = new Response();

            string Query = "insert into students values(@ID, @FirstName, @LastName, @Email)";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@ID", student.Id);
            cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
            cmd.Parameters.AddWithValue("@LastName", student.LastName);
            cmd.Parameters.AddWithValue("@Email", student.email);
            con.Open();

            int i = cmd.ExecuteNonQuery();

            if(i > 0)
            {
                response.statusCode=200;// it is successful
                response.statusMessage = "Data Entry Successful";
                response.student = student;
            }
            else
            { 
                response.statusCode = 100; // it is not successful
                response.statusMessage = "Data Entry is not Successful";
                
            }
            con.Close();
            return response;
        }

        public Response updateStudent(NpgsqlConnection con, Student student)
        {
            Response response = new Response();

            string Query = "Update students Set LastName='@LastName', email='@Email' Where id=@ID";
            NpgsqlCommand cmd = new NpgsqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
            cmd.Parameters.AddWithValue("@LastName", student.LastName);
            cmd.Parameters.AddWithValue("@Email", student.email);
            cmd.Parameters.AddWithValue("@ID", student.Id);
            con.Open();

            int i = cmd.ExecuteNonQuery();
            
            con.Close();

            if (i > 0)
            {
                response.statusCode=200; // successful query
                response.statusMessage = "The data is updated perfectly";
                response.student = student;
            }
            else
            {
                response.statusCode = 100;
                response.statusMessage = "No data updated properly";
            }
            
            return response;
        }

        public Response DeleteStudent(NpgsqlConnection con, int id)
        {
            Response response = new Response();

            string Query = "Delete from students where id='"+ id +"'";
            NpgsqlCommand cmd = new NpgsqlCommand( Query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if(i > 0)
            {
                response.statusCode=200; // Successfully deleted
                response.statusMessage = "The entry is delected from Table";
                
            }
            else
            {
                response.statusCode=100; // delete couldn't be possible
                response.statusMessage = "delete couldn't be possible";
            }
            con.Close ();
            return response;
        }
    }
}
