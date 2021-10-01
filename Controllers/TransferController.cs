using Internship.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Internship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TransferController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select * from dbo.transfer";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Internship");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet("getFrom/{from_no}")]
        public JsonResult Get(string from_no)
        {
            string query = @"
                select * from dbo.transfer
                where from_no=@from_no   ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Internship");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@from_no", from_no);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet("getTo/{to_no}")]
        public JsonResult Get(string to_no, int de)
        {
            string query = @"
                select * from dbo.transfer
                where to_no=@to_no";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Internship");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@to_no", to_no);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(transfer trnsfr)
        {
            string query = @"
                insert into transfer
                values(@from_name, @from_no, @from_iban, @to_name, @to_no, @to_iban, @total, @date)
                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Internship");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@from_name", trnsfr.from_name);
                    myCommand.Parameters.AddWithValue("@from_no", trnsfr.from_no);
                    myCommand.Parameters.AddWithValue("@from_iban", trnsfr.from_iban);
                    myCommand.Parameters.AddWithValue("@to_name", trnsfr.to_name);
                    myCommand.Parameters.AddWithValue("@to_no", trnsfr.to_no);
                    myCommand.Parameters.AddWithValue("@to_iban", trnsfr.to_iban);
                    myCommand.Parameters.AddWithValue("@total", trnsfr.total);
                    myCommand.Parameters.AddWithValue("@date", trnsfr.date);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("transfer added successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from transfer
                where id=@id
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Internship");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("transfer deleted successfully");
        }
    }
}
