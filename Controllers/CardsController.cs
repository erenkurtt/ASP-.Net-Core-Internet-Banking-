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
    public class CardsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CardsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select * from dbo.cards";

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
        public JsonResult Get(string card_no)
        {
            string query = @"
                select * from dbo.cards
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

        public JsonResult Post(cards card)
        {
            string query = @"
                insert into cards
                values (@username, @bank_id, @card_no, @last_month, @last_year, @ccv, @limit, @debt, @currency )
                ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Internship");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@username", card.username);
                    myCommand.Parameters.AddWithValue("@bank_id", card.bank_id);
                    myCommand.Parameters.AddWithValue("@card_no", card.card_no);
                    myCommand.Parameters.AddWithValue("@last_month", card.last_month);
                    myCommand.Parameters.AddWithValue("@last_year", card.last_year);
                    myCommand.Parameters.AddWithValue("@ccv", card.ccv);
                    myCommand.Parameters.AddWithValue("@limit", card.limit);
                    myCommand.Parameters.AddWithValue("@debt", card.debt);
                    myCommand.Parameters.AddWithValue("@currency", card.currency);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("card added successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from cards
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

            return new JsonResult("card deleted successfully");
        }

        [HttpPatch("{id}")]
        public JsonResult Patch(int id, cards card)
        {
            string query = @"
                update cards
                set limit=@limit , debt=@debt
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
                    myCommand.Parameters.AddWithValue("@limit", Math.Round(card.limit * 100) / 100);
                    myCommand.Parameters.AddWithValue("@debt", Math.Round(card.debt * 100) / 100);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("card changed successfully");
        }

    }
}
