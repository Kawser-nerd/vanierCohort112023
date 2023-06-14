using Microsoft.AspNetCore.Mvc;
using Npgsql;
using RestAPICohort.Models;

namespace RestAPICohort.Controllers
{
    public class StudentsController : ControllerBase
    {
        // create a connection state retriever, which will hold the connection information from the remote server
        private readonly IConfiguration _configuration;

        public StudentsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // now our goal is to create the wrapper for each of the Rest API methods which we created in Application class

        [HttpGet] // the protocol the API is going to follow, the accessability of the API
        [Route("GetAllStudents")] // this is going to set the name of the API. You can choose any name, not need to be
        // same as any other name

        public Response GetAllStudents()
        {
            NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("studentConnection").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetAllStudents(connection); // we are going to pass the sql connection to the API method body developed
            // inside the application class
            return response;

        }

        [HttpGet]
        [Route("GetStudentByID")]
        public Response GetStudentByID(int id) {

            NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("studentConnection").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.GetStudentbyID(connection, id);
            return response;
        }

        [HttpPost]
        [Route("AddStudent")]
        public Response AddStudent(Student student)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("studentConnection").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.AddStudent(connection, student);
            return response;

        }

        [HttpPost]
        [Route("UpdateStudent")]
        public Response UpdateStudent(Student student)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("studentConnection").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.updateStudent(connection, student);
            return response;
        }

        [HttpDelete]
        [Route("DeleteStudent")]
        public Response DeleteStudent(int id)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("studentConnection").ToString());
            Response response = new Response();
            Application apl = new Application();
            response = apl.DeleteStudent(connection, id);
            return response;
        }
    }
}
