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
    public class CardPaymentsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CardPaymentsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select * from dbo.cardpayments";

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

        [HttpGet("{card_no}")]
        public JsonResult Get( string card_no)
        {
            string query = @"
                select * from dbo.cardpayments
                where card_no=@card_no";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Internship");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@card_no", card_no);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(cardpayments cardpay)
        {
            string query = @"
                insert into cardpayments 
                values (@username, @bank_id, @card_no, @cost, @to_where, @date)
                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Internship");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@username", cardpay.username);
                    myCommand.Parameters.AddWithValue("@bank_id", cardpay.bank_id);
                    myCommand.Parameters.AddWithValue("@card_no", cardpay.card_no);
                    myCommand.Parameters.AddWithValue("@cost", cardpay.cost);
                    myCommand.Parameters.AddWithValue("@to_where", cardpay.to_where);
                    myCommand.Parameters.AddWithValue("@date", cardpay.date);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("payment added successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from cardpayments
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

            return new JsonResult("payment deleted successfully");
        }
    }
}
