using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Village_MVC.Models;

namespace Village_MVC.Controllers.api
{
   
    public class OldController : ApiController
    {
        static string connectionString = "Data Source=laptop-a88v89ut;Initial Catalog=OldDB;Integrated Security=True;Pooling=False";
        OldContextDataContext DataContext = new OldContextDataContext(connectionString);
        // GET: api/Old
        public IHttpActionResult Get()
        {
            try
            {
                List<Old> OldList = DataContext.Olds.ToList();
                return Ok(new { OldList });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Old
        public IHttpActionResult Get(int id)
        {
            try
            {
                Old OneOld = DataContext.Olds.First((oldItem) => oldItem.Id == id);
                return Ok(new { OneOld });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception )
            {
                return NotFound();
            }
        }

        // POST: api/Old
        public IHttpActionResult Post([FromBody]Old old)
        {
            try
            {
                DataContext.Olds.InsertOnSubmit(old);
                DataContext.SubmitChanges();
                return Ok("success");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Old/5
        public IHttpActionResult Put(int id, [FromBody] Old Old)
        {
            try
            {
                Old OldToUpdate = DataContext.Olds.Single(OldItem => OldItem.Id == id);
                OldToUpdate = Old;
                DataContext.SubmitChanges();


                return Ok("success");

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Old/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Old RemoveOld = DataContext.Olds.First(OldItem => OldItem.Id == id);
                DataContext.Olds.DeleteOnSubmit(RemoveOld);
                DataContext.SubmitChanges();
                return Ok("Removed");
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
